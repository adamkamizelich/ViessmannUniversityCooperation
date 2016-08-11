using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityIot.UI.Core.Services;
using UniversityIot.UI.Core.ViewModels;
using Xamarin.Forms;

namespace UniversityIot.UI.Core.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            this.BindingContext = new LoginViewModel(new UserManagementService());
        }
    }
}
