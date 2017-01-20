using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityIot.DataAccess.Authentication;
using UniversityIot.DataAccess.DTO;
using UniversityIot.DataAccess.Models;

namespace UniversityIot.DataAccess.Services
{
    public class DatapointsRestService : BaseUniversityIotRestService, IDatapointsRepository
    {
        public DatapointsRestService(ICredentialsProvider credentialsProvider)
            : base(credentialsProvider)
        {
        }

        public async Task<List<DatapointModel>> GetByInstallationId(long installationId)
        {
            DatapointsDTO rawJson = await this.GetData<DatapointsDTO>($"gateways/{installationId}/datapoints");
            return rawJson.Data;
        }

        public async Task SaveChanges(DatapointModel datapointModel)
        {
            await this.SaveData($"datapoints/{datapointModel.Id}", datapointModel.DatapointValue);
        }

        public async Task<DatapointModel> GetByDatapointId(long datapointId)
        {
            DatapointDTO rawJson = await this.GetData<DatapointDTO>($"gateways/1/datapoints/{datapointId}");
            return rawJson.Data;
        }
    }
}