namespace UniversityIot.UsersDataAccess.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string CustomerNumber { get; set; }

        public string Password { get; set; }

        public ICollection<UserInstallation> InstallationIds { get; set; }
    }
}
