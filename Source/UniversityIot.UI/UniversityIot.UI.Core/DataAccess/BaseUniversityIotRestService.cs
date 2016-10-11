using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UniversityIot.UI.Core.DataAccess
{
    public abstract class BaseUniversityIotRestService
    {
        protected readonly Uri BaseUri = new Uri("http://universityiotvitocontrolapi.azurewebsites.net");
        protected readonly IAppSession Session;

        protected BaseUniversityIotRestService(IAppSession session)
        {
            Session = session;
        }

        private IUserAuth User => Session.UserAuth;

        protected async Task<TDto> GetData<TDto>(string restMethod)
        {
            return await GetData<TDto>(restMethod, User.Name, User.Password);
        }

        protected async Task<TDto> GetData<TDto>(string restMethod, string user, string pass)
        {
            var uri = new Uri($"{BaseUri}{restMethod}");

            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential(user, pass)
            };

            using (var client = new HttpClient(handler))
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TDto>(content);
                }
                Session.ClearUserSession();
                throw new Exception($"Error retreiving {uri}, statusCode: {response.StatusCode}");
            }
        }
    }
}