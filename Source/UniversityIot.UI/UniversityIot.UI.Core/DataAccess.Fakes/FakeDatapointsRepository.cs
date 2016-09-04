using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityIot.UI.Core.Models;

namespace UniversityIot.UI.Core.DataAccess.Fakes
{
    public class FakeDatapointsRepository : IDatapointsRepository
    {
        private readonly List<DatapointModel> datapoints = new List<DatapointModel>
        {
            new DatapointModel
            {
                Description = "description",
                HexAddress = "0x9999",
                Id = 1,
                IsReadOnly = false,
                DatapointValue = 15.ToString()
            },
            new DatapointModel
            {
                Description = "description2",
                HexAddress = "0x2222",
                Id = 2,
                IsReadOnly = false,
                DatapointValue = 11.ToString()
            }
        };

        public Task<List<DatapointModel>> GetByInstallationId(long installationId)
        {
            return Task.FromResult(this.datapoints);
        }

        public Task<DatapointModel> GetByDatapointId(long datapointId)
        {
            DatapointModel datapointModel = this.datapoints.FirstOrDefault(dp => dp.Id == datapointId);
            return Task.FromResult(datapointModel);
        }

        public void SaveChanges(DatapointModel datapointModel)
        {
            DatapointModel oldDatapointModel = this.datapoints.Single(dp => dp.Id == datapointModel.Id);
            oldDatapointModel.DatapointValue = datapointModel.DatapointValue;
        }
    }
}