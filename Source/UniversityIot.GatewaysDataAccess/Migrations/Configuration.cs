namespace UniversityIot.GatewaysDataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    using UniversityIot.Enums;
    using UniversityIot.GatewaysDataAccess.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityIot.GatewaysDataAccess.GatewaysContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GatewaysContext context)
        {
            context.Gateways.AddOrUpdate(
                new Gateway() {Id = 1, Description = "A", SerialNumber = "111"});
            context.Gateways.AddOrUpdate(
                new Gateway() {Id = 2, Description = "B", SerialNumber = "222"});
            context.Gateways.AddOrUpdate(
                new Gateway() {Id = 3, Description = "C", SerialNumber = "333"});
            context.Gateways.AddOrUpdate(
                new Gateway() { Id = 4, Description = "D", SerialNumber = "444" });
            context.Gateways.AddOrUpdate(
                new Gateway() { Id = 5, Description = "E", SerialNumber = "555" });
            context.Gateways.AddOrUpdate(
                new Gateway() { Id = 6, Description = "F", SerialNumber = "666" });

            context.GatewaySettings.AddOrUpdate(
                new GatewaySetting()
                {
                    Id = 1,
                    Description = "Outside temperature",
                    HexAdress = "111",
                    DataType = SettingDataType.Div10,
                    IsReadonly = false
                });
            context.GatewaySettings.AddOrUpdate(
                new GatewaySetting()
                {
                    Id = 2,
                    Description = "Inside temperature",
                    HexAdress = "222",
                    DataType = SettingDataType.Div10,
                    IsReadonly = false
                });
            context.GatewaySettings.AddOrUpdate(
                new GatewaySetting()
                {
                    Id = 3,
                    Description = "Desired temperature",
                    HexAdress = "333",
                    DataType = SettingDataType.Div10,
                    IsReadonly = true
                });
        }
    }
}
