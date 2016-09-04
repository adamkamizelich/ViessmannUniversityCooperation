using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityIot.UI.Core.Models;

namespace UniversityIot.UI.Core.DataAccess.Fakes
{
    public class FakeInstallationRepository : IInstallationsRepository
    {
        private readonly List<InstallationModel> installations = new List<InstallationModel>
        {
            new InstallationModel
            {
                Id = 1,
                Description = "test installation",
                SerialNumber = "9023840923789084723"
            }
        };

        public InstallationModel GetInstallationById(long installationId)
        {
            return this.installations.FirstOrDefault(installation => installation.Id == installationId);
        }

        public Task<List<InstallationModel>> GetAllByUserId(long userId)
        {
            return Task.FromResult(this.installations);
        }
    }
}