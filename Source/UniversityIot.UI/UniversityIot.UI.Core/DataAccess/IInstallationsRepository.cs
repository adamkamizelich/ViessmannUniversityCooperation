namespace UniversityIot.UI.Core.DataAccess
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UniversityIot.UI.Core.Models;

    public interface IInstallationsRepository
    {
        Task<InstallationModel> GetInstallationById(long installationId);

        Task<List<InstallationModel>> GetAllByUserId(long userId);
    }
}