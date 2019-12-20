using ABBLicensApp.Annotations;
using ABBLicensApp.Common;
using ABBLicensApp.Model;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ABBLicensApp.Viewmodel
{
    class EditCustomerViewModel : INotifyPropertyChanged
    {
        public EditCustomerViewModel()
        {
            CancelThis = new GoBackCommand();
            RegisterCustomerBtn = new RelayCommand(AddCustomer);
            Shared = StaticClassSingleton.Instance;
        }

        //Metoder

        private void AddCustomer()
        {
            foreach (var c in Shared.Customers)
            {
                if (c.CompanyName == Shared.SelectedCustomer.CompanyName)
                {
                    c.CompanyName = Name;
                    c.Address = Addr;
                    c.ContactName = Contact;
                    c.Email = Email;
                    c.PhoneNumber = Phone;
                }
            }
            Navigation.GoBack();
        }

        //Properties

        public string Name
        {
            get => Shared.SelectedCustomer.CompanyName;
            set
            {
                if (value == Shared.SelectedCustomer.CompanyName) return;
                Shared.SelectedCustomer.CompanyName = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get => Shared.SelectedCustomer.PhoneNumber;
            set
            {
                if (value == Shared.SelectedCustomer.PhoneNumber) return;
                Shared.SelectedCustomer.PhoneNumber = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => Shared.SelectedCustomer.Email;
            set
            {
                if (value == Shared.SelectedCustomer.Email) return;
                Shared.SelectedCustomer.Email = value;
                OnPropertyChanged();
            }
        }

        public string Contact
        {
            get => Shared.SelectedCustomer.ContactName;
            set
            {
                if (value == Shared.SelectedCustomer.ContactName) return;
                Shared.SelectedCustomer.ContactName = value;
                OnPropertyChanged();
            }
        }

        public string Addr
        {
            get => Shared.SelectedCustomer.Address;
            set
            {
                if (value == Shared.SelectedCustomer.Address) return;
                Shared.SelectedCustomer.Address = value;
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
