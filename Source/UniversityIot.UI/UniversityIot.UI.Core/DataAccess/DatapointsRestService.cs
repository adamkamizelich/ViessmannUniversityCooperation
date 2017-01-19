namespace UniversityIot.UI.Core.DataAccess
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UniversityIot.UI.Core.DataAccess.DTO;
    using UniversityIot.UI.Core.Models;

    public class DatapointsRestService : BaseUniversityIotRestService, IDatapointsRepository
    {
        public DatapointsRestService(IAppSession session)
            : base(session)
        {
        }

        public async Task<List<DatapointModel>> GetByInstallationId(long installationId)
        {
            DatapointsDTO rawJson = await this.GetData<DatapointsDTO>($"gateways/{installationId}/datapoints");
            return rawJson.Data;
        }

        // TODO async
        public void SaveChanges(DatapointModel datapointModel)
        {
            // TODO

            /*
              // PutData(restMethod) in base class
              var uri = $"{this.baseUri}{restMethod}";
              var json = JsonConvert.SerializeObject(item);
              var content = new StringContent(json, Encoding.UTF8, "application/json");

              HttpResponseMessage response = null;
              response = await client.PostAsync(uri, content);

              if (!response.IsSuccessStatusCode)
              {
                  // log error
              }
            */
        }

        public async Task<DatapointModel> GetByDatapointId(long datapointId)
        {
            DatapointDTO rawJson = await this.GetData<DatapointDTO>($"datapoints/{datapointId}");
            return rawJson.Data;
        }
    }
}