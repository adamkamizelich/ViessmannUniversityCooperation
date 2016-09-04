using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using UniversityIot.UI.Core.Models;

namespace UniversityIot.UI.Core.DataAccess
{
    public interface IInstallationsRepository
    {
        Task<InstallationModel> GetInstallationById(long installationId);
        Task<List<InstallationModel>> GetAllByUserId(long userId);
    }
}