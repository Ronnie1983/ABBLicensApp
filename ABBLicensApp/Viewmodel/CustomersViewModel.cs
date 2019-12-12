using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Profile;
using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class CustomersViewModel
    {
        public CustomersViewModel()
        {
            GoToSelected = new RelayCommand(GoToCustomerDetails);
            GoBack = new RelayCommand(GoBackToMain);
            NewCustomerBtn = new RelayCommand(NewCustomer);
            Shared = StaticClassSingleton.Instance;
        }

        public RelayCommand NewCustomerBtn { get; set; }

        private void NewCustomer()
        {
            Navigation.GoToPage("AddCustomer");
        }

        public RelayCommand GoBack { get; set; }

        public void GoBackToMain()
        {
            Navigation.GoToPage("LoginSucceed");
        }

        public StaticClassSingleton Shared { get; }

        private void GoToCustomerDetails()
        {
            Navigation.GoToPage("Customer", SelectedCustomer);
        }


        public RelayCommand GoToSelected { get; set; }

        public Customer SelectedCustomer
        {
            get => Shared.SelectedCustomer;
            set => Shared.SelectedCustomer = value;
        }

        public ObservableCollection<Customer> Customers
        {
            get => Shared.Customers;
            set => Shared.Customers = value;
        }
    }
}
