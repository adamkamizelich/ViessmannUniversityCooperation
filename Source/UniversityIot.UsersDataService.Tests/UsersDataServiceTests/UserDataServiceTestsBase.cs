namespace UniversityIot.UsersDataService.Tests.UsersDataServiceTests
{
    using System.Threading.Tasks;
    using NUnit.Framework;
    using UniversityIot.Tests.Common.DataAccessMocks;
    using UniversityIot.UsersDataAccess;
    using UniversityIot.UsersDataAccess.Models;

    public class UserDataServiceTestsBase
    {
        public virtual UsersContext CreateContext()
        {
            return new UserContextMock();
        }

        public virtual async Task<User> CreateFakeUser()
        {
            var user = new User
            {
                CustomerNumber = "Fake number",
                Name = "Fake name",
                Password = "Fake password"
            };

            using (var context = CreateContext())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
            return user;
        }

        public virtual UsersDataService GetService()
        {
            var service = new UsersDataService(() => this.CreateContext());
            return service;
        }

        [SetUp]
        public virtual void Setup()
        {
            this.Teardown();
        }

        [TearDown]
        public virtual void Teardown()
        {
            var context = new UserContextMock();
            context.Database.ExecuteSqlCommand("delete from UserInstallations");
            context.Database.ExecuteSqlCommand("delete from Users");
        }
    }
}
