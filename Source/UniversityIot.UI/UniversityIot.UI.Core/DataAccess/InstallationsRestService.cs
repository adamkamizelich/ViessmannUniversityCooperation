using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UniversityIot.UI.Core.DataAccess.DTO;
using UniversityIot.UI.Core.Models;

namespace UniversityIot.UI.Core.DataAccess
{
    public class InstallationsRestService : IInstallationsRepository
    {
        private readonly Uri baseUri = new Uri("http://universityiotvitocontrolapi.azurewebsites.net");
        public readonly HttpClient client;

        public InstallationsRestService()
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

        public async Task<InstallationModel> GetInstallationById(long installationId)
        {
            var uri = new Uri($"{this.baseUri}/gateways/{installationId}");

            var response = await this.client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var rawJson = JsonConvert.DeserializeObject<InstallationDTO>(content);

                // Map to model
                return rawJson.Data;
            }

            // TODO handle error
            return new InstallationModel();
        }

        public async Task<List<InstallationModel>> GetAllByUserId(long userId)
        {
            var uri = new Uri($"{this.baseUri}/users/{userId}/gateways");

            var response = await this.client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var rawJson = JsonConvert.DeserializeObject<InstallationsDTO>(content);

                // Map to model
                return rawJson.Data;
            }

            // TODO handle error
            return new List<InstallationModel>();
        }
    }
}