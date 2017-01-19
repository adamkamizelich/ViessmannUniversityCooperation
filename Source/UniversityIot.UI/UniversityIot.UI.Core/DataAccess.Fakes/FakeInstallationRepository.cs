namespace UniversityIot.UI.Core.DataAccess.Fakes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversityIot.UI.Core.Models;

    public class FakeInstallationRepository : IInstallationsRepository
    {
        private readonly List<InstallationModel> installations = new List<InstallationModel>
        {
            new InstallationModel
            {
                Id = 1,
                Description = "test installation 1",
                SerialNumber = "7343126764852354682"
            },
            new InstallationModel
            {
                Id = 2,
                Description = "test installation 2",
                SerialNumber = "9023840923789084723"
            },
            new InstallationModel
            {
                Id = 3,
                Description = "test installation 3",
                SerialNumber = "8754329010457432089"
            },
            new InstallationModel
            {
                Id = 4,
                Description = "test installation 4",
                SerialNumber = "5433247234784843254"
            },
            new InstallationModel
            {
                Id = 5,
                Description = "test installation 5",
                SerialNumber = "5423094378312579983"
            },
        };

        public Task<InstallationModel> GetInstallationById(long installationId)
        {
            InstallationModel installationModel =
                this.installations.FirstOrDefault(installation => installation.Id == installationId);

            return Task.FromResult(installationModel);
        }

        public Task<List<InstallationModel>> GetAllByUserId(long userId)
        {
            return Task.FromResult(this.installations);
        }
    }
}