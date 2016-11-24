namespace UniversityIot.UsersDataService.Tests.UsersDataServiceTests
{
    using NUnit.Framework;
    using UniversityIot.UsersDataAccess;
    using UniversityIot.UsersDataAccess.Models;

    public class UserDataServiceTestsBase
    {
        public virtual User CreateFakeUser()
        {
            var user = new User
            {
                CustomerNumber = "1234567890",
                Name = "Fake name",
                Password = "Fake password"
            };
            
            return user;
        }

        public virtual UsersDataService GetService()
        {
            var service = new UsersDataService();
            return service;
        }

        [SetUp]
        public virtual void Setup()
        {
            Teardown();
        }

        [TearDown]
        public virtual void Teardown()
        {
            //using (var context = new UsersContext())
            //{
            //    context.Database.ExecuteSqlCommand("delete from UserGateways");
            //    context.Database.ExecuteSqlCommand("delete from Users");
            //}
        }
    }
}