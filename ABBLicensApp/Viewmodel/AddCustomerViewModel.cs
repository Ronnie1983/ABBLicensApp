using System.ComponentModel;
using System.Runtime.CompilerServices;
using ABBLicensApp.Annotations;
using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class AddCustomerViewModel : ViewModel
    {
        private string _name;
        private string _phone;
        private string _email;
        private string _contact;
        private string _addr;

        public AddCustomerViewModel()
        {
            CancelThis = new GoBackCommand();
            RegisterCustomerBtn = new RelayCommand(AddCustomerAndGoBack);
            Shared = StaticClassSingleton.Instance;
        }

        //Metoder

        private void AddCustomerAndGoBack()
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
                SetProperty<string>(ref _addr, value);
            }
        }

        
        public string Name
        {
            get => _name;
            set
            {
                SetProperty<string>(ref _name, value);
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                SetProperty<string>(ref _phone, value);
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                SetProperty<string>(ref _email, value);
            }
        }

        public string Contact
        {
            get => _contact;
            set
            {
                SetProperty<string>(ref _contact, value);
            }
        }

        public StaticClassSingleton Shared { get; }

        public RelayCommand RegisterCustomerBtn { get; set; }

        public RelayCommand CancelThis { get; set; }
    }
}
