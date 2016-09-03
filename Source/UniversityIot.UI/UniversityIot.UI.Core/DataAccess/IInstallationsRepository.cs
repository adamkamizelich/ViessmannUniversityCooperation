using UniversityIot.UI.Core.Models;

namespace UniversityIot.UI.Core.DataAccess
{
    public interface IInstallationsRepository
    {
        InstallationModel GetInstallationById(long installationId);
    }
}