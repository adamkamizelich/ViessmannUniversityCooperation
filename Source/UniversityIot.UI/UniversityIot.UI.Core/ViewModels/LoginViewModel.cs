using System;
using System.Diagnostics;
using System.Windows.Input;
using UniversityIot.UI.Core.DataAccess;
using UniversityIot.UI.Core.Models;
using UniversityIot.UI.Core.MVVM;
using UniversityIot.UI.Core.Services;
using UniversityIot.UI.Core.Views;
using Xamarin.Forms;

namespace UniversityIot.UI.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ICredentialsService credentialsService;
        private readonly IInstallationsRepository installationsRepository;
        private readonly IAppSession appSession;
        private readonly IUsersRepository usersRepository;
        private string errorMessage;

        private string password;
        private string userName;

        public LoginViewModel(IAppSession appSession, IUsersRepository usersRepository, ICredentialsService credentialsService, IInstallationsRepository installationsRepository)
        {
            this.appSession = appSession;
            this.usersRepository = usersRepository;
            this.installationsRepository = installationsRepository;
            this.credentialsService = credentialsService;

            UserName = "john.doe@viessmann.com";
            Password = "ViessmannJD";

            if (this.credentialsService.CredentialsExist())
            {
                UserName = this.credentialsService.UserName;
                Password = this.credentialsService.Password;
            }
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                if (value == userName) return;
                userName = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                // todo hack
                if (value == null)
                {
                    return;
                }

                if (value == password) return;
                password = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                if (value == errorMessage) return;
                errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand => new Command(async () =>
        {
            try
            {
                var user = await usersRepository.GetUser(UserName, Password);


                appSession.InitUserSession(new UserAuth(1, UserName, Password));

              /*  UserModel user = new UserModel()
                {
                    CustomerNumber = 1,
                    Id = 1,
                    Name = UserName
                };*/

                if (user == null || user.Name != UserName)
                {
                    ErrorMessage = "User name or password is invalid";
                    credentialsService.DeleteCredentials();
                    appSession.ClearUserSession();
                    return;
                }

                credentialsService.SaveCredentials(UserName, Password);
                ErrorMessage = string.Empty;
              /*
                var installationModels = await installationsRepository.GetAllByUserId(user.Id);
                var userInstallationsViewModel = new UserInstallationsViewModel(installationModels);*/

                var masterDetailViewModel = new InstalationsMasterDetailViewModel();

                await this.NavigationService.Push(masterDetailViewModel);

                //await NavigationService.Push(userInstallationsViewModel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error while authenticating", ex);
            }
        });
    }
}