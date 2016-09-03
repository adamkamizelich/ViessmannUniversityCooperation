using UniversityIot.UI.Core.MVVM;

namespace UniversityIot.UI.Core.Models
{
    public class InstallationModel : BaseModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
    }
}