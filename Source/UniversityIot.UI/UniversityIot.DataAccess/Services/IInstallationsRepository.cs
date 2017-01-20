using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityIot.DataAccess.Models;

namespace UniversityIot.DataAccess.Services
{
    public interface IInstallationsRepository
    {
        Task<InstallationModel> GetInstallationById(long installationId);

        Task<List<InstallationModel>> GetAllByUserId(long userId);
    }
}