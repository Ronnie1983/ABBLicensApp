using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store.Preview.InstallControl;
using ABBLicensApp.Annotations;
using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class RegisterPageViewModel : INotifyPropertyChanged
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

        public RelayCommand RegisterButton { get; set; }

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
                if (value == _newPassword) return;
                _newPassword = value;
                OnPropertyChanged();
            }
        }

        public string RePassword
        {
            get => _rePassword;
            set
            {
                if (value == _rePassword) return;
                _rePassword = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (value == _email) return;
                _email = value;
                OnPropertyChanged();
            }
        }

        public void RegUser()
        {
            Shared.UsersCollection.Add(new User(NewName,NewPassword));
            Shared.NavigationClass.GoToRegistrationSucceedButtonNavigation();
        }

        public StaticClassSingleton Shared { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
