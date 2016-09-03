using System.Collections.Generic;
using UniversityIot.UI.Core.Models;

namespace UniversityIot.UI.Core.DataAccess
{
    public class DatapointsRepository : IDatapointsRepository
    {
        public List<DatapointModel> GetByInstallationId(long installationId)
        {
            return new List<DatapointModel>
            {
                new DatapointModel
                {
                    Description = "description",
                    HexAddress = "0x9999",
                    Id = 1,
                    IsReadOnly = false,
                    Value = 15
                },
                new DatapointModel
                {
                    Description = "description",
                    HexAddress = "0x9999",
                    Id = 1,
                    IsReadOnly = false,
                    Value = 15
                }
            };
        }
    }
}