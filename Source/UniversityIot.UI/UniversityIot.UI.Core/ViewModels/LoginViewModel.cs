using UniversityIot.DataAccess.Authentication;
using UniversityIot.DataAccess.Models;
using UniversityIot.DataAccess.Services;

namespace UniversityIot.UI.Core.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;
    using UniversityIot.UI.Core.Services;
    using UniversityIot.UI.Mvvm;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        private readonly ICredentialsProvider credentialsProvider;
        private readonly IAuthenticationService authenticationService;
        private readonly ICredentialsService credentialsService;
        private readonly INavigationService navigationService;
        private string errorMessage;
        private string password;
        private string userName;

        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                if (value == this.userName)
                {
                    return;
                }

                this.userName = value;
                this.OnPropertyChanged();
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if (value == this.password)
                {
                    return;
                }

                this.password = value;
                this.OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }
            set
            {
                if (value == this.errorMessage)
                {
                    return;
                }

                this.errorMessage = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand LoginCommand => new Command(async () =>
        {
            try
            {
                UserModel user = await this.authenticationService.Authenticate(this.UserName, this.Password);

                if (this.IsUserLogged(user))
                {
                    this.InitializeSession(user);
                    this.ErrorMessage = string.Empty;

                    var masterDetailViewModel = new InstalationsMasterDetailViewModel();
                    await this.navigationService.Push(masterDetailViewModel);
                }
                else
                {
                    this.ErrorMessage = "User name or password is invalid";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error while authenticating. {ex}");
                await this.navigationService.PopToRootAsync();
            }
        });

        public LoginViewModel(
            ICredentialsProvider credentialsProvider,
            IAuthenticationService authenticationService,
            ICredentialsService credentialsService,
            INavigationService navigationService)
        {
            this.credentialsProvider = credentialsProvider;
            this.authenticationService = authenticationService;
            this.navigationService = navigationService;
            this.credentialsService = credentialsService;

            // HACK, fill credentials for development
            this.UserName = "john.doe@viessmann.com";
            this.Password = "ViessmannJD";

            if (this.credentialsService.CredentialsExist())
            {
                this.UserName = this.credentialsService.UserName;
                this.Password = this.credentialsService.Password;
            }
        }

        private void InitializeSession(UserModel user)
        {
            var userAuth = new UserAuth(user.Id, this.UserName, this.Password);
            this.credentialsProvider.InitUserSession(userAuth);
            this.credentialsService.SaveCredentials(this.UserName, this.Password);
        }

        private bool IsUserLogged(UserModel user)
        {
            // Just a showcase implementation
            return ((user != null) && string.Equals(user.Name, this.UserName) && (user.Id > 0));
        }
    }
}