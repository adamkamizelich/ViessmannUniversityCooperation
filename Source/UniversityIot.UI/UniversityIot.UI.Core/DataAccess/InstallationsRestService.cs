using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UniversityIot.UI.Core.DataAccess.DTO;
using UniversityIot.UI.Core.Models;

namespace UniversityIot.UI.Core.DataAccess
{
    public class InstallationsRestService : BaseUniversityIotRestService, IInstallationsRepository
    {
        public async Task<InstallationModel> GetInstallationById(long installationId)
        {
            InstallationDTO rawJson = await this.GetData<InstallationDTO>($"gateways/{installationId}");

            // Map to model
            return rawJson.Data;
        }

        public async Task<List<InstallationModel>> GetAllByUserId(long userId)
        {
            InstallationsDTO rawJson = await this.GetData<InstallationsDTO>($"users/{userId}/gateways");

            // Map to model
            return rawJson.Data;
        }
    }
}