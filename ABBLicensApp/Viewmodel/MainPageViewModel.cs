using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ABBLicensApp.Annotations;
using ABBLicensApp.Common;
using ABBLicensApp.Model;
using ABBLicensApp.View;

namespace ABBLicensApp.Viewmodel
{
    class MainPageViewModel
    {
        private string _newName; // Holds the name of the login in login screen
        private string _newPassword; // Holds the password inserted in logins creen

        public MainPageViewModel() // Constructor of the viewmodel
        {
            LoginCommand = new RelayCommand(LoginMetode); // create the object of a login method
            GoToRegisterPage = new RelayCommand(GoToRegisterPageMethod); // Create the object of a register method
            Shared = StaticClassSingleton.Instance; // calls the property that returns a instance field whom create the static common class
        }

        public StaticClassSingleton Shared { get; }

        public RelayCommand LoginCommand { get; set; } // makes the login button possible to access login method

        public RelayCommand GoToRegisterPage { get; set; } // makes the register button possible to access register method

        public string NewName // properties for the inserted name at login
        {
            get => _newName;
            set
            {
                if (value == _newName) return;
                _newName = value;
            }
        }

        public string NewPassword // properties for the inserted password at login
        {
            get => _newPassword;
            set
            {
                if (value == _newPassword) return;
                _newPassword = value;
            }
        }

        public void GoToRegisterPageMethod() // the register method
        {
            Shared.NavigationClass.RegistrationButtonNavigation(); // calls the method navigate to registerpage
        }

        private void LoginMetode() // The login method
        {
            foreach (var aUser in Shared.UsersCollection) // controls if user exists
            {
                if (NewName == aUser.Username && NewPassword == aUser.Password)
                {
                    Shared.CurrentUser = NewName;
                    Shared.NavigationClass.LoginButtonNavigation();
                }
            }
        }
    }
}
