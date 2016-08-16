namespace UniversityIot.UsersDataService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UniversityIot.UsersDataAccess.Models;

    public interface IUsersDataService
    {
        Task<User> GetUserAsync(int id);

        Task<User> GetUserAsync(string name);
        
        Task<IEnumerable<int>> GetUsersInstallationsAsync(int userId);

        Task<bool> ValidateUserAsync(string name, string password);
    }
}
