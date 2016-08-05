namespace UniversityIot.UsersDataAccess
{
    using System.Data.Entity;
    using UniversityIot.UsersDataAccess.Models;

    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("UniversityIot.Users")
        {
        }

        public IDbSet<User> Users { get; set; }
    }
}
