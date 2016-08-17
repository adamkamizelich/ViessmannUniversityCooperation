namespace UniversityIot.UsersDataAccess.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using UniversityIot.UsersDataAccess.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityIot.UsersDataAccess.UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "UniversityIot.UsersDataAccess.UsersContext";
        }

        private static UserInstallation InstallationLink(int installationId)
        {
            return new UserInstallation
            {
                InstallationId = installationId,
            };
        }

        protected override void Seed(UsersContext context)
        {
            var userWithOneInstallation = new User
            {
                CustomerNumber = "210299",
                InstallationIds = new List<UserInstallation> { InstallationLink(1) },
                Name = "john.doe@viessmann.com",
                Password = "54b83c6d63fa7d7d1b281e8f0aab4c0d" // ViessmannJD
            };


            var userWithTwoInstallations = new User
            {
                CustomerNumber = "651902",
                InstallationIds = new List<UserInstallation> { InstallationLink(2), InstallationLink(3) },
                Name = "jan.kowalski@viessmann.com",
                Password = "d54d6a139b63b92fb5ac148b66ff67f6" // ViessmannJK
            };

            var userWithThreeInstallations = new User
            {
                CustomerNumber = "651902",
                InstallationIds = new List<UserInstallation> { InstallationLink(4), InstallationLink(5), InstallationLink(6) },
                Name = "hans.schmitt@viessmann.com",
                Password = "1ca988de20343b73124c5c15387259bd" // ViessmannHS
            };

            context.Users.Add(userWithOneInstallation);
            context.Users.Add(userWithTwoInstallations);
            context.Users.Add(userWithThreeInstallations);
        }
    }
}
