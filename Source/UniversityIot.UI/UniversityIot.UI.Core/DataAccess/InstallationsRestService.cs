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

        public InstallationModel GetInstallationById(long installationId)
        {
            return null;
        }

        public async Task<List<InstallationModel>> GetAllByUserId(long userId)
        {
            var uri = new Uri($"http://universityiotvitocontrolapi.azurewebsites.net/users/{userId}/gateways");
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