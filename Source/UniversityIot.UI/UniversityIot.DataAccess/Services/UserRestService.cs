using System.Threading.Tasks;
using UniversityIot.DataAccess.Authentication;
using UniversityIot.DataAccess.DTO;
using UniversityIot.DataAccess.Models;

namespace UniversityIot.DataAccess.Services
{
    public class UserRestService : BaseUniversityIotRestService, IUsersRepository
    {
        public UserRestService(ICredentialsProvider credentialsProvider) 
            : base(credentialsProvider)
        {
        }

        public async Task<UserModel> GetUserById(int id)
        {
            UserDTO rawJson = await this.GetData<UserDTO>($"users/{id}");
            return rawJson.Data;
        }
    }
}