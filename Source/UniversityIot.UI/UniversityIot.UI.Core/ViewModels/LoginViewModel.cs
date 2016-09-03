using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UniversityIot.UI.Core.Services;
using Xamarin.Forms;

namespace UniversityIot.UI.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly UserManagementService userManagementService;
        private readonly ICredentialsService credentialsService;

        public LoginViewModel(UserManagementService userManagementService, ICredentialsService credentialsService)
        {
            this.userManagementService = userManagementService;
            this.credentialsService = credentialsService;
        }

        private string _password;
        private string _userName;
        private string _errorMessage;

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (value == _userName) return;
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (value == _errorMessage) return;
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(() =>
                {
                    var isLogged = userManagementService.Login(this.UserName, this.Password);

                    if (!isLogged)
                    {
                        ErrorMessage = "User name or password is invalid";
                        return;
                    }

                    ErrorMessage = string.Empty;

                    credentialsService.SaveCredentials(this.UserName, this.Password);

                    ErrorMessage = "Logged";

                });
            }
        }
    }
}
