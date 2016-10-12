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
                new Gateway() {Id = 1, Description = "Vitoconnect 100/1", SerialNumber = "7571381602761103" });
            context.Gateways.AddOrUpdate(
                new Gateway() {Id = 2, Description = "Vitoconnect 100/2", SerialNumber = "7571381602761105" });
            context.Gateways.AddOrUpdate(
                new Gateway() {Id = 3, Description = "Vitoconnect 100/3", SerialNumber = "7571381602761109" });
            context.Gateways.AddOrUpdate(
                new Gateway() { Id = 4, Description = "Heatbox 2/1", SerialNumber = "7571381602761140" });
            context.Gateways.AddOrUpdate(
                new Gateway() { Id = 5, Description = "Heatbox 2/2", SerialNumber = "7571381602761142" });
            context.Gateways.AddOrUpdate(
                new Gateway() { Id = 6, Description = "Heatbox 2/3", SerialNumber = "7571381602761143" });

            context.GatewaySettings.AddOrUpdate(
                new GatewaySetting()
                {
                    Id = 1,
                    Description = "Outside temperature",
                    HexAdress = "5525",
                    DataType = SettingDataType.Div10,
                    IsReadonly = true
                });
            context.GatewaySettings.AddOrUpdate(
                new GatewaySetting()
                {
                    Id = 2,
                    Description = "Inside temperature",
                    HexAdress = "0896",
                    DataType = SettingDataType.Div10,
                    IsReadonly = true
                });
            context.GatewaySettings.AddOrUpdate(
                new GatewaySetting()
                {
                    Id = 3,
                    Description = "Desired temperature",
                    HexAdress = "2306",
                    DataType = SettingDataType.NoConversion,
                    IsReadonly = false
                });
        }
    }
}
