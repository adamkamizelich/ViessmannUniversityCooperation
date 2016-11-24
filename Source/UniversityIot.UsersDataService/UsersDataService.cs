namespace UniversityIot.UsersDataService
{
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using UniversityIot.UsersDataAccess;
    using UniversityIot.UsersDataAccess.Models;

    public class UsersDataService : IUsersDataService
    {
        public async Task<User> AddUserAsync(User user)
        {
            using (var context = new UsersContext())
            {
                context.Users.Add(user);

                await context.SaveChangesAsync();

                return user;
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            using (var context = new UsersContext())
            {
                var user = await context
                    .Users
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (user != null)
                {
                    context.Users.Remove(user);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<User> GetUserAsync(int id)
        {
            using (var context = new UsersContext())
            {
                var user = await context
                    .Users
                    .Include(x => x.UserGateways)
                    .FirstOrDefaultAsync(x => x.Id == id);

                return user;
            }
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            using (var context = new UsersContext())
            {
                context.Users.Attach(user);
                context.Entry(user).State = EntityState.Modified;

                await context.SaveChangesAsync();

                return user;
            }
        }
    }
}