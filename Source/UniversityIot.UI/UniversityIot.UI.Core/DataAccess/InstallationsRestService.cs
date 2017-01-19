namespace UniversityIot.UI.Core.DataAccess
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UniversityIot.UI.Core.DataAccess.DTO;
    using UniversityIot.UI.Core.Models;

    public class InstallationsRestService : BaseUniversityIotRestService, IInstallationsRepository
    {
        public InstallationsRestService(IAppSession session)
            : base(session)
        {
        }

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