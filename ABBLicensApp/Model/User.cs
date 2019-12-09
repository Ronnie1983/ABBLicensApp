using System.ComponentModel;
using System.Runtime.CompilerServices;
using ABBLicensApp.Annotations;

namespace ABBLicensApp.Model
{
    public class User : INotifyPropertyChanged
    {
        private string _username;
        private string _password;

        public User(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public string Username
        {
            get => _username;
            set
            {
                if (value == _username) return;
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}