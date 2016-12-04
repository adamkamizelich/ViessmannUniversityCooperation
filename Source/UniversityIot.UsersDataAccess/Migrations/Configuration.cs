namespace UniversityIot.UsersDataAccess.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using UniversityIot.Enums;
    using UniversityIot.UsersDataAccess.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private static UserGateway GatewayLink(int gatewayId)
        {
            return new UserGateway
            {
                Id = gatewayId,
                GatewaySerial = "Serial" + gatewayId,
                AccessType = GatewayAccessType.Owner
            };
        }

        protected override void Seed(UsersContext context)
        {
            var userWithOneInstallation = new User
            {
                Id = 1,
                CustomerNumber = "210299",
                UserGateways = new List<UserGateway> { GatewayLink(1) },
                Name = "john.doe@viessmann.com",
                Password = "54b83c6d63fa7d7d1b281e8f0aab4c0d" // ViessmannJD
            };


            var userWithTwoInstallations = new User
            {
                Id = 2,
                CustomerNumber = "651902",
                UserGateways = new List<UserGateway> { GatewayLink(2), GatewayLink(3) },
                Name = "jan.kowalski@viessmann.com",
                Password = "d54d6a139b63b92fb5ac148b66ff67f6" // ViessmannJK
            };

            var userWithThreeInstallations = new User
            {
                Id = 3,
                CustomerNumber = "109439",
                UserGateways = new List<UserGateway> { GatewayLink(4), GatewayLink(5), GatewayLink(6) },
                Name = "hans.schmitt@viessmann.com",
                Password = "1ca988de20343b73124c5c15387259bd" // ViessmannHS
            };

            context.Users.AddOrUpdate(userWithOneInstallation);
            context.Users.AddOrUpdate(userWithTwoInstallations);
            context.Users.AddOrUpdate(userWithThreeInstallations);
        }
    }
}
