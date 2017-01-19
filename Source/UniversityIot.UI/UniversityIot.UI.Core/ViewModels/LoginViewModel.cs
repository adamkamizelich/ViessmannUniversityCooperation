namespace UniversityIot.UI.Core.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;
    using UniversityIot.UI.Core.DataAccess;
    using UniversityIot.UI.Core.Models;
    using UniversityIot.UI.Core.Services;
    using UniversityIot.UI.Mvvm;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        private readonly IAppSession appSession;
        private readonly ICredentialsService credentialsService;
        private readonly INavigationService navigationService;
        private readonly IUsersRepository usersRepository;
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
                // todo hack
                if (value == null)
                {
                    return;
                }

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
                UserModel user = await this.usersRepository.GetUser(this.UserName, this.Password);
                var userAuth = new UserAuth(1, this.UserName, this.Password);

                this.appSession.InitUserSession(userAuth);

                if (user == null || !string.Equals(user.Name, this.UserName))
                {
                    this.ErrorMessage = "User name or password is invalid";
                    this.credentialsService.DeleteCredentials();
                    this.appSession.ClearUserSession();
                    return;
                }

                this.credentialsService.SaveCredentials(this.UserName, this.Password);
                this.ErrorMessage = string.Empty;

                var masterDetailViewModel = new InstalationsMasterDetailViewModel();

                await this.navigationService.Push(masterDetailViewModel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error while authenticating. {ex}");
            }
        });

        public LoginViewModel(
            IAppSession appSession,
            IUsersRepository usersRepository,
            ICredentialsService credentialsService,
            INavigationService navigationService)
        {
            this.appSession = appSession;
            this.usersRepository = usersRepository;
            this.navigationService = navigationService;
            this.credentialsService = credentialsService;

            // HACK
            this.UserName = "john.doe@viessmann.com";
            this.Password = "ViessmannJD";

            if (this.credentialsService.CredentialsExist())
            {
                this.UserName = this.credentialsService.UserName;
                this.Password = this.credentialsService.Password;
            }
        }
    }
}