using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UniversityIot.DataAccess.Authentication;

namespace UniversityIot.DataAccess.Services
{
    public abstract class BaseUniversityIotRestService
    {
        private readonly ICredentialsProvider credentialsProvider;
        protected readonly Uri baseUri = new Uri("http://universityiotvitocontrolapi.azurewebsites.net");

        protected BaseUniversityIotRestService(ICredentialsProvider credentialsProvider)
        {
            this.credentialsProvider = credentialsProvider;
        }

        protected async Task<TDto> GetData<TDto>(string restMethod)
        {
            return await this.GetData<TDto>(restMethod, this.credentialsProvider.UserAuth.Name, this.credentialsProvider.UserAuth.Password);
        }

        protected async Task<TDto> GetData<TDto>(string restMethod, string userArg, string passArg)
        {
            var uri = new Uri($"{this.baseUri}{restMethod}");

            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential(userArg, passArg)
            };

            using (var client = new HttpClient(handler))
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TDto>(content);
                }

                throw new Exception($"Error retreiving {uri}, statusCode: {response.StatusCode}");
            }
        }

        protected async Task SaveData<TDto>(string restMethod, TDto data)
        {
            var uri = $"{this.baseUri}{restMethod}";
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential(this.credentialsProvider.UserAuth.Name, this.credentialsProvider.UserAuth.Password)
            };

            using (var client = new HttpClient(handler))
            {
                HttpResponseMessage response = await client.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error retreiving {uri}, statusCode: {response.StatusCode}");
                }
            }
        }
    }
}