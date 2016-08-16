namespace UniversityIot.UsersDataService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversityIot.UsersDataService.Models;

    public class FakeUsersDataService : IUsersDataService
    {
        private static readonly IEnumerable<User> Users = new List<User>()
        {
            new User() {Id = 1, Name = "A", CustomerNumber = "111"},
            new User() {Id = 2, Name = "B", CustomerNumber = "222"},
            new User() {Id = 3, Name = "C", CustomerNumber = "333"}
        };

        public Task<User> GetUser(int id)
        {
            var user = Users.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(user);
        }

        public Task SaveUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            return Task.FromResult(Users);
        }

        public Task<IEnumerable<int>> GetUsersInstallations(int userId)
        {
            var user = Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                return Task.FromResult(new[] { userId }.AsEnumerable());
            }

            return null;
        }
    }
}