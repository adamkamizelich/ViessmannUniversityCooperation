using System.Collections.Generic;
using UniversityIot.UI.Core.Models;

namespace UniversityIot.UI.Core.DataAccess
{
    public interface IInstallationsRepository
    {
        InstallationModel GetInstallationById(long installationId);
        List<InstallationModel> GetAllByUserId(long userId);
    }
}