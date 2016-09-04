using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityIot.UI.Core.Models;

namespace UniversityIot.UI.Core.DataAccess
{
    public interface IDatapointsRepository
    {
        Task<List<DatapointModel>> GetByInstallationId(long installationId);
        void SaveChanges(DatapointModel datapointModel);
        Task<DatapointModel> GetByDatapointId(long datapointId);
    }
}