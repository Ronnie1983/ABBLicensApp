using System.ComponentModel;
using System.Runtime.CompilerServices;
using ABBLicensApp.Annotations;
using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class RegisterPageViewModel : ViewModel
    {
        private string _newName;
        private string _newPassword;
        private string _email;
        private string _rePassword;

        public RegisterPageViewModel()
        {
            Shared = StaticClassSingleton.Instance;
            RegisterButton = new RelayCommand(RegUser);
        }

        //Metoder
        public void RegUser()
        {
            if (NewPassword == RePassword)
            {
                Shared.UsersCollection.Add(new User(NewName, NewPassword));
                Navigation.GoToPage("RegistrationSucceed");
            }
        }

        //Properties

        public string NewName
        {
            get => _newName;
            set
            {
                if (value == _newName) return;
                _newName = value;
                OnPropertyChanged();
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

        public string RePassword
        {
            get => _rePassword;
            set
            {
                SetProperty<string>(ref _rePassword, value);
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                SetProperty<string> (ref _email, value);
            }
        }
        public RelayCommand RegisterButton { get; set; }

        public StaticClassSingleton Shared { get; }
    }
}
