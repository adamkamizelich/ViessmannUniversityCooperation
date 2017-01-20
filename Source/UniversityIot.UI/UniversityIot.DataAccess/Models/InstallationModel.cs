namespace UniversityIot.DataAccess.Models
{
    public class InstallationModel : BaseModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
    }
}