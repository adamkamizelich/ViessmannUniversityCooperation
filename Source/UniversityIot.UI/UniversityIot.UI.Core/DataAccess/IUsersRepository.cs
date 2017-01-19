namespace UniversityIot.UI.Core.DataAccess
{
    using System.Threading.Tasks;
    using UniversityIot.UI.Core.Models;

    public interface IUsersRepository
    {
        Task<UserModel> GetUser(string login, string password);

        Task<UserModel> GetUserById(int id);
    }
}