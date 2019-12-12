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
        private ObservableCollection<Customer> _customers;

        public CustomersViewModel()
        {
            _customers = new ObservableCollection<Customer>()
            { 
                new Customer("Roskilde Vand Forsyning", "vandgade 12", "ros@vand.com", "22334456", "Jan"),
                new Customer("Holbæk Ild Forsyning", "ilddgade 12", "hold@ild.com", "66671122", "Torkild"),
                new Customer("Vanløse Jord Forsyning", "jordgade 12", "van@jord.com", "12341234", "Thor")
            };

            GoToSelected = new RelayCommand(GoToCustomerDetails);
            Shared = StaticClassSingleton.Instance;

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
            get => _customers;
            set => _customers = value;
        }
    }
}
