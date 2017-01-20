using System.Threading.Tasks;
using UniversityIot.DataAccess.Models;

namespace UniversityIot.DataAccess.Services
{
    public interface IAuthenticationService
    {
        Task<UserModel> Authenticate(string login, string password);
    }
}