using System.Threading.Tasks;
using UniversityIot.UI.Core.Models;

namespace UniversityIot.UI.Core.DataAccess
{
    public interface IUsersRepository
    {
        Task<UserModel> GetUser(string login, string password);
        Task<UserModel> GetUserById(int id);
    }
}