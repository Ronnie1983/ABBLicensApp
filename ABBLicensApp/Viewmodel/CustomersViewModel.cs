using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ABBLicensApp.Annotations;
using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class CustomersViewModel : INotifyPropertyChanged
    {
        public CustomersViewModel()
        {
            GoBack = new RelayCommand(GoBackOnePage);
            NewCustomerBtn = new RelayCommand(NewCustomer);
            Shared = StaticClassSingleton.Instance;
            SelectedCustomer = null;
        }

        public RelayCommand NewCustomerBtn { get; set; }

        public RelayCommand GoBack { get; set; }

        public StaticClassSingleton Shared { get; }

        public Customer SelectedCustomer
        {
            get => Shared.SelectedCustomer;
            set
            {
                Shared.SelectedCustomer = value;
                if (SelectedCustomer != null)
                {
                    Navigation.GoToPage("Customer");
                }
            } 
        }

        public string SearchCustomerText
        {
            get { return Shared.SearchCustomerText; }
            set
            {
                Shared.SearchCustomerText = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FilteredCustomers));
            }
        }

        public ObservableCollection<Customer> FilteredCustomers
        {
            get => Shared.FilteredCustomers;
            set
            {
                Shared.FilteredCustomers = value;
                OnPropertyChanged();
            } 
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

        public void GoBackOnePage()
        {
            Navigation.GoBack();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
