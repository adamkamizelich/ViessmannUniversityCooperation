using System.Collections.Generic;
using UniversityIot.UI.Core.Models;

namespace UniversityIot.UI.Core.DataAccess
{
    public interface IDatapointsRepository
    {
        List<DatapointModel> GetByInstallationId(long installationId);
    }
}