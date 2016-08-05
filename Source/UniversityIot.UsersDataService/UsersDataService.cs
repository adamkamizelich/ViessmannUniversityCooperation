namespace UniversityIot.UsersDataService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UniversityIot.UsersDataAccess;
    using Entity = UniversityIot.UsersDataAccess.Models;
    using UniversityIot.UsersDataService.Models;

    public class UsersDataService : IUsersDataService
    {
        public Task<User> GetUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task SaveUser(User user)
        {
            using (var context = new UsersContext())
            {
                var userToSave = new Entity.User
                {
                    CustomerNumber = user.CustomerNumber,
                    Name = user.Name
                };
                context.Users.Add(userToSave);
                await context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}
