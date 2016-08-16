namespace UniversityIot.UsersDataService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using UniversityIot.UsersDataAccess;
    using UniversityIot.UsersDataAccess.Models;

    public class UsersDataService : IUsersDataService
    {
        public async Task<User> GetUserAsync(string name)
        {
            var user = await GetUserAsync(u => u.Name == name);
            return user;
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await GetUserAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<int>> GetUsersInstallationsAsync(int userId)
        {
            using (var context = new UsersContext())
            {
                var installationIds = await context.Users
                    .Where(u => u.Id == userId)
                    .SelectMany(u => u.InstallationIds, (user1, installation) => installation.Id)
                    .ToListAsync();

                return installationIds;
            }
        }

        public Task<bool> ValidateUserAsync(string name, string password)
        {
            throw new NotImplementedException();
        }

        private static async Task<User> GetUserAsync(Expression<Func<User, bool>> predicate)
        {
            using (var context = new UsersContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(predicate);
                return user;
            }
        }
    }
}
