using ABBLicensApp.Annotations;
using ABBLicensApp.Common;
using ABBLicensApp.Model;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ABBLicensApp.Viewmodel
{
    class EditCustomerViewModel : ViewModel
    {
        private Customer _proxyCustomer;
        private string _originalName;

        public EditCustomerViewModel()
        {
            CancelThis = new GoBackCommand();
            RegisterCustomerBtn = new RelayCommand(UpdateCustomer);
            Shared = StaticClassSingleton.Instance;
            ProxyCustomer = new Customer(Shared.SelectedCustomer);

            _originalName = ProxyCustomer.CompanyName;
        }

        //Metoder

        private void UpdateCustomer()
        {
            Customer cust = Shared.Customers.Single((c) => c.CompanyName == _originalName);

            if (cust != null)
            {
                cust.CompanyName = Name;
                cust.Address = Addr;
                cust.ContactName = Contact;
                cust.Email = Email;
                cust.PhoneNumber = Phone;

                Navigation.GoBack();
            }
        }

        //Properties

        public Customer ProxyCustomer
        {
            get => _proxyCustomer;
            set => _proxyCustomer = value;
        }

        public string Name
        {
            get => ProxyCustomer.CompanyName;
            set
            {
                ProxyCustomer.CompanyName = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get => ProxyCustomer.PhoneNumber;
            set
            {
                ProxyCustomer.PhoneNumber = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => ProxyCustomer.Email;
            set
            {
                ProxyCustomer.Email = value;
                OnPropertyChanged();
            }
        }

        public string Contact
        {
            get => ProxyCustomer.ContactName;
            set
            {
                ProxyCustomer.ContactName = value;
                OnPropertyChanged();
            }
        }

        public string Addr
        {
            get => ProxyCustomer.Address;
            set
            {
                ProxyCustomer.Address = value;
                OnPropertyChanged();
            }
        }

        public StaticClassSingleton Shared { get; }
        public RelayCommand RegisterCustomerBtn { get; set; }
        public RelayCommand CancelThis { get; set; }
    }
}
