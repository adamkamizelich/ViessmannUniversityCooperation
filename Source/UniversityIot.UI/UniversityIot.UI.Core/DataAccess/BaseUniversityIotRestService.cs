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
        private readonly HttpClient client;

        protected BaseUniversityIotRestService()
        {
            var handler = new HttpClientHandler
            {
                // TODO
                Credentials = new NetworkCredential("john.doe@viessmann.com", "ViessmannJD")
            };

            this.client = new HttpClient(handler)
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        protected async Task<TDto> GetData<TDto>(string restMethod)
        {
            var uri = new Uri($"{this.BaseUri}{restMethod}");

            var response = await this.client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TDto>(content);
            }

            throw new Exception($"Error retreiving {uri}, statusCode: {response.StatusCode}");
        }
    }
}