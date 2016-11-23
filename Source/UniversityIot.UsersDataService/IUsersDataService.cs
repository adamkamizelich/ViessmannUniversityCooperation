namespace UniversityIot.UsersDataService
{
    using System.Threading.Tasks;
    using UniversityIot.UsersDataAccess.Models;

    public interface IUsersDataService
    {
        Task<User> GetUserAsync(int id);

        Task<User> AddUserAsync(User user);

        Task DeleteUserAsync(int id);

        Task<User> UpdateUserAsync(User user);
    }
}