using System.Threading.Tasks;
using UniversityIot.DataAccess.Models;

namespace UniversityIot.DataAccess.Services
{
    public interface IUsersRepository
    {
        Task<UserModel> GetUserById(int id);
    }
}