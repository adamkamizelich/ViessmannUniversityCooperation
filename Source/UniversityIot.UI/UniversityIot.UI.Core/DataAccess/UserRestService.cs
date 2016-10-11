using System;
using System.Threading.Tasks;
using UniversityIot.UI.Core.DataAccess.DTO;
using UniversityIot.UI.Core.Models;

namespace UniversityIot.UI.Core.DataAccess
{
    public class UserRestService : BaseUniversityIotRestService, IUsersRepository
    {
        public UserRestService(IAppSession session) : base(session)
        {
        }

        public async Task<UserModel> GetUser(string login, string password)
        {
            try
            {
                var rawJson = await GetData<UserDTO>($"users/me", login, password);
                var user = rawJson.Data;
                IUserAuth userAuth = new UserAuth(user.Id, user.Name, password);
                Session.InitUserSession(userAuth);

                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<UserModel> GetUserById(int id)
        {
            var rawJson = await GetData<UserDTO>($"users/{id}");

            return rawJson.Data;
        }
    }
}