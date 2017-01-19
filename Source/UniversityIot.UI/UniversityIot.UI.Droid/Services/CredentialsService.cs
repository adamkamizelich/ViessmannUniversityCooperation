using UniversityIot.UI.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(CredentialsService))]

namespace UniversityIot.UI.Droid.Services
{
    using System;
    using System.Linq;
    using UniversityIot.UI.Core;
    using UniversityIot.UI.Core.Services;
    using Xamarin.Auth;

    internal class CredentialsService : ICredentialsService
    {
        private const string PasswordKey = "Password";

        public string UserName
        {
            get
            {
                Account account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
                return account?.Username;
            }
        }

        public string Password
        {
            get
            {
                Account account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
                return account?.Properties[PasswordKey];
            }
        }

        public void SaveCredentials(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("", nameof(userName));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("", nameof(password));
            }

            var account = new Account
            {
                Username = userName
            };
            account.Properties.Add(PasswordKey, password);
            AccountStore.Create().Save(account, App.AppName);
        }

        public void DeleteCredentials()
        {
            Account account = AccountStore.Create().FindAccountsForService(App.AppName).FirstOrDefault();
            if (account != null)
            {
                AccountStore.Create().Delete(account, App.AppName);
            }
        }

        public bool CredentialsExist()
        {
            bool result = AccountStore.Create().FindAccountsForService(App.AppName).Any();

            return result;
        }
    }
}