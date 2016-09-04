using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UniversityIot.UI.Core.DataAccess;
using UniversityIot.UI.Core.Models;
using UniversityIot.UI.Core.MVVM;
using UniversityIot.UI.Core.Services;
using Xamarin.Forms;

namespace UniversityIot.UI.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly UserManagementService userManagementService;
        private readonly IInstallationsRepository installationsRepository;
        private readonly ICredentialsService credentialsService;

        public LoginViewModel(
            UserManagementService userManagementService, 
            ICredentialsService credentialsService,
            IInstallationsRepository installationsRepository)
        {
            this.userManagementService = userManagementService;
            this.installationsRepository = installationsRepository;
            this.credentialsService = credentialsService;
        }

        private string password;
        private string userName;
        private string errorMessage;

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
                var isLogged = userManagementService.Login(this.UserName, this.Password);

                if (!isLogged)
                {
                    ErrorMessage = "User name or password is invalid";
                    return;
                }

                ErrorMessage = string.Empty;
                credentialsService.SaveCredentials(this.UserName, this.Password);

                // TODO
                const long userId = 1;
                List<InstallationModel> installationModels = await this.installationsRepository.GetAllByUserId(userId);
                var userInstallationsViewModel = new UserInstallationsViewModel(installationModels);
                await this.NavigationService.Push(userInstallationsViewModel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error while authenticating", ex);
            }
        });
    }
}
