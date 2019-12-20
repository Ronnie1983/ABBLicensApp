using System.ComponentModel;
using System.Runtime.CompilerServices;
using ABBLicensApp.Annotations;
using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class AddCustomerViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _phone;
        private string _email;
        private string _contact;
        private string _addr;

        public AddCustomerViewModel()
        {
            CancelThis = new GoBackCommand();
            RegisterCustomerBtn = new RelayCommand(AddCustomer);
            Shared = StaticClassSingleton.Instance;
        }

        //Metoder

        private void AddCustomer()
        {
            Shared.Customers.Add(new Customer(Name, Addr, Email, Phone, Contact));
            Navigation.GoBack();
        }

        //Properties

        public string Addr
        {
            get => _addr;
            set
            {
                if (value == _addr) return;
                _addr = value;
                OnPropertyChanged();
            }
        }

        
        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (value == _phone) return;
                _phone = value;
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

        public string Contact
        {
            get => _contact;
            set
            {
                if (value == _contact) return;
                _contact = value;
                OnPropertyChanged();
            }
        }

        public StaticClassSingleton Shared { get; }

        public RelayCommand RegisterCustomerBtn { get; set; }

        public RelayCommand CancelThis { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
