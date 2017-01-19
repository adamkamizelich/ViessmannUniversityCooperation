namespace UniversityIot.UI.Core.DataAccess
{
    using System;
    using System.Threading.Tasks;
    using UniversityIot.UI.Core.DataAccess.DTO;
    using UniversityIot.UI.Core.Models;

    public class UserRestService : BaseUniversityIotRestService, IUsersRepository
    {
        public UserRestService(IAppSession session)
            : base(session)
        {
        }

        public async Task<UserModel> GetUser(string login, string password)
        {
            try
            {
                UserDTO rawJson = await this.GetData<UserDTO>("users/me", login, password);
                UserModel user = rawJson.Data;
                IUserAuth userAuth = new UserAuth(user.Id, user.Name, password);
                this.session.InitUserSession(userAuth);

                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<UserModel> GetUserById(int id)
        {
            UserDTO rawJson = await this.GetData<UserDTO>($"users/{id}");

            return rawJson.Data;
        }
    }
}