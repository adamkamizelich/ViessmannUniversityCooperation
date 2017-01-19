namespace UniversityIot.UI.Core.DataAccess
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public abstract class BaseUniversityIotRestService
    {
        protected readonly Uri baseUri = new Uri("http://universityiotvitocontrolapi.azurewebsites.net");
        protected readonly IAppSession session;
        private IUserAuth User => this.session.UserAuth;

        protected BaseUniversityIotRestService(IAppSession session)
        {
            this.session = session;
        }

        protected async Task<TDto> GetData<TDto>(string restMethod)
        {
            return await this.GetData<TDto>(restMethod, this.User.Name, this.User.Password);
        }

        protected async Task<TDto> GetData<TDto>(string restMethod, string user, string pass)
        {
            var uri = new Uri($"{this.baseUri}{restMethod}");

            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential(user, pass)
            };

            using (var client = new HttpClient(handler))
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TDto>(content);
                }

                this.session.ClearUserSession();
                throw new Exception($"Error retreiving {uri}, statusCode: {response.StatusCode}");
            }
        }
    }
}