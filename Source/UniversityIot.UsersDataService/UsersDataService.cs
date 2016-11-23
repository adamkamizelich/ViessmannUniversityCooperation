namespace UniversityIot.UsersDataService
{
    using System;
    using System.Threading.Tasks;
    using UniversityIot.UsersDataAccess;
    using UniversityIot.UsersDataAccess.Models;

    public class UsersDataService : IUsersDataService
    {
        private readonly Func<UsersContext> contextLocator;

        public UsersDataService()
        {
            contextLocator = () => new UsersContext();
        }

        public UsersDataService(Func<UsersContext> contextLocator)
        {
            this.contextLocator = contextLocator;
        }

        public Task<User> AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}