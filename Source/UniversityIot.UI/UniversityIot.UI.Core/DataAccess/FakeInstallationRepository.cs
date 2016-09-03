using UniversityIot.UI.Core.Models;

namespace UniversityIot.UI.Core.DataAccess
{
    public class FakeInstallationRepository : IInstallationsRepository
    {
        public InstallationModel GetInstallationById(long installationId)
        {
            // TODO
            return new InstallationModel
            {
                Id = 1,
                Description = "test installation",
                SerialNumber = "9023840923789084723"
            };
        }
    }
}