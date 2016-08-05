namespace UniversityIot.UsersDataService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UniversityIot.UsersDataService.Models;

    public interface IUsersDataService
    {
        Task<User> GetUser(int id);

        Task SaveUser(User user);

        Task<IEnumerable<User>> GetAllUsers();
    }
}
