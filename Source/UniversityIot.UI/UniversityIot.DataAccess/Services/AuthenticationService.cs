using System;
using System.Diagnostics;
using System.Threading.Tasks;
using UniversityIot.DataAccess.Authentication;
using UniversityIot.DataAccess.DTO;
using UniversityIot.DataAccess.Models;

namespace UniversityIot.DataAccess.Services
{
    public class AuthenticationService : BaseUniversityIotRestService, IAuthenticationService
    {
        public AuthenticationService(ICredentialsProvider credentialsProvider) 
            : base(credentialsProvider)
        {
        }

        public async Task<UserModel> Authenticate(string login, string password)
        {
            try
            {
                UserDTO rawJson = await this.GetData<UserDTO>("users/me", login, password);
                return rawJson.Data;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error Authenticate: {ex}");
                return null;
            }
        }
    }
}