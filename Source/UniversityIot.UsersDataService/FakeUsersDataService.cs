namespace UniversityIot.UsersDataService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversityIot.UsersDataAccess.Models;

    public class FakeUsersDataService : IUsersDataService
    {
        private static readonly IEnumerable<User> Users = new List<User>()
        {
            new User() {Id = 1, Name = "A", CustomerNumber = "111"},
            new User() {Id = 2, Name = "B", CustomerNumber = "222"},
            new User() {Id = 3, Name = "C", CustomerNumber = "333"}
        };

        public Task<User> GetUserAsync(int id)
        {
            var user = Users.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(user);
        }

        public Task<User> GetUserAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            return Task.FromResult(Users);
        }

        public Task<IEnumerable<int>> GetUsersInstallationsAsync(int userId)
        {
            var user = Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                return Task.FromResult(new[] { userId }.AsEnumerable());
            }

            return null;
        }

        public Task<bool> ValidateUserAsync(string name, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}