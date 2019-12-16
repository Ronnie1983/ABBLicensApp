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

        public RelayCommand GoBack { get; set; }

        public StaticClassSingleton Shared { get; }

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

        private void NewCustomer()
        {
            Navigation.GoToPage("AddCustomer");
        }

        private void GoToCustomerDetails()
        {
            if (SelectedCustomer != null)
            {
                Navigation.GoToPage("Customer");
            }
        }

        public void GoBackOnePage()
        {
            Navigation.GoBack();
        }
    }
}
