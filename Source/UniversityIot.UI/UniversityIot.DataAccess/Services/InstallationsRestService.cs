using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityIot.DataAccess.Authentication;
using UniversityIot.DataAccess.DTO;
using UniversityIot.DataAccess.Models;

namespace UniversityIot.DataAccess.Services
{
    public class InstallationsRestService : BaseUniversityIotRestService, IInstallationsRepository
    {
        public InstallationsRestService(ICredentialsProvider credentialsProvider) 
            : base(credentialsProvider)
        {
        }

        public async Task<InstallationModel> GetInstallationById(long installationId)
        {
            InstallationDTO rawJson = await this.GetData<InstallationDTO>($"gateways/{installationId}");
            return rawJson.Data;
        }

        public async Task<List<InstallationModel>> GetAllByUserId(long userId)
        {
            InstallationsDTO rawJson = await this.GetData<InstallationsDTO>($"users/{userId}/gateways");
            return rawJson.Data;
        }
    }
}