using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityIot.DataAccess.Models;

namespace UniversityIot.DataAccess.Services
{
    public interface IDatapointsRepository
    {
        Task<List<DatapointModel>> GetByInstallationId(long installationId);

        Task SaveChanges(DatapointModel datapointModel);

        Task<DatapointModel> GetByDatapointId(long datapointId);
    }
}