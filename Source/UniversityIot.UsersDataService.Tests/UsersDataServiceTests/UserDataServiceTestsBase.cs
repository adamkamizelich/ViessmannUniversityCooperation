namespace UniversityIot.UsersDataService.Tests.UsersDataServiceTests
{
    using System.Threading.Tasks;
    using NUnit.Framework;
    using UniversityIot.UsersDataAccess;
    using UniversityIot.UsersDataAccess.Models;

    public class UserDataServiceTestsBase
    {
        public virtual async Task<User> CreateFakeUser()
        {
            var user = new User
            {
                CustomerNumber = "Fake number",
                Name = "Fake name",
                Password = "Fake password"
            };

            //using (var context = CreateContext())
            //{
            //    context.Users.Add(user);
            //    await context.SaveChangesAsync();
            //}
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
            //using (var context = this.CreateContext())
            //{
            //    context.Database.ExecuteSqlCommand("delete from UserGateways");
            //    context.Database.ExecuteSqlCommand("delete from Users");
            //}
        }
    }
}