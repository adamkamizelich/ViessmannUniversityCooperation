using System;
using System.Linq;
using UniversityIot.UI.Core;
using UniversityIot.UI.Core.Services;
using UniversityIot.UI.iOS.Services;
using Xamarin.Auth;
using Xamarin.Forms;

[assembly: Dependency(typeof(CredentialsService))]

namespace UniversityIot.UI.iOS.Services
{
    internal class CredentialsService : ICredentialsService
    {
        private const string PasswordKey = "Password";

        public string UserName
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
                return account?.Username;
            }
        }

        public string Md5Password
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
                return account?.Properties[PasswordKey];
            }
        }

        public void SaveCredentials(string userName, string md5Password)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("", nameof(userName));
            }

            if (string.IsNullOrWhiteSpace(md5Password))
            {
                throw new ArgumentException("", nameof(md5Password));
            }

            var account = new Account
            {
                Username = userName
            };
            account.Properties.Add(PasswordKey, md5Password);
            AccountStore.Create().Save(account, App.AppName);
        }

        public void DeleteCredentials()
        {
            var account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
            if (account != null)
            {
                AccountStore.Create().Delete(account, App.AppName);
            }
        }

        public bool CredentialsExist()
        {
            var result = AccountStore.Create().FindAccountsForService(App.AppName).Any();

            return result;
        }
    }
}