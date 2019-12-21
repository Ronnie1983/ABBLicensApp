using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    class MainPageViewModel : ViewModel
    {
        private string _newName; // Holds the name of the login in login screen
        private string _newPassword; // Holds the password inserted in logins creen

        public MainPageViewModel() // Constructor of the viewmodel
        {
            LoginCommand = new RelayCommand(LoginMethod);
            GoToRegisterPage = new GoToPageCommand("Registration");
            Shared = StaticClassSingleton.Instance;
        }

        //Metoder
        private void LoginMethod()
        {
            foreach (var aUser in Shared.UsersCollection)
            {
                if (NewName == aUser.Username && NewPassword == aUser.Password)
                {
                    Shared.CurrentUser = NewName;
                    Navigation.GoToPage("LoginSucceed");
                }
            }
        }

        //Properties

        public string NewName
        {
            get => _newName;
            set
            {
                SetProperty<string>(ref _newName, value);
            }
        }

        public string NewPassword
        {
            get => _newPassword;
            set
            {
                SetProperty<string>(ref _newPassword, value);
            }
        }
        public StaticClassSingleton Shared { get; }
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand GoToRegisterPage { get; set; }


    }
}
