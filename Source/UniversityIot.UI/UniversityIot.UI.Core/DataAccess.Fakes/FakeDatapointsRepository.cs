using System.Collections.Generic;
using System.Linq;
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
                DatapointValue = 15
            },
            new DatapointModel
            {
                Description = "description2",
                HexAddress = "0x2222",
                Id = 2,
                IsReadOnly = false,
                DatapointValue = 11 
            }
        };

        public List<DatapointModel> GetByInstallationId(long installationId)
        {
            return this.datapoints;
        }

        public DatapointModel GetByDatapointId(long datapointId)
        {
            return this.datapoints.FirstOrDefault(dp => dp.Id == datapointId);
        }

        public void SaveChanges(DatapointModel datapointModel)
        {
            DatapointModel oldDatapointModel = this.datapoints.Single(dp => dp.Id == datapointModel.Id);
            oldDatapointModel.DatapointValue = datapointModel.DatapointValue;
        }
    }
}