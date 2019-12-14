using System.Collections.ObjectModel;
using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class CustomersViewModel
    {
        public CustomersViewModel()
        {
            GoToSelected = new RelayCommand(GoToCustomerDetails);
            GoBack = new RelayCommand(GoBackOnePage);
            NewCustomerBtn = new RelayCommand(NewCustomer);
            Shared = StaticClassSingleton.Instance;
        }

        public RelayCommand NewCustomerBtn { get; set; }

        private void NewCustomer()
        {
            Navigation.GoToPage("AddCustomer");
        }

        public RelayCommand GoBack { get; set; }

        public void GoBackOnePage()
        {
            Navigation.GoBack();
        }

        public StaticClassSingleton Shared { get; }

        private void GoToCustomerDetails()
        {
            if (SelectedCustomer != null)
            {
                Navigation.GoToPage("Customer");
            }
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
