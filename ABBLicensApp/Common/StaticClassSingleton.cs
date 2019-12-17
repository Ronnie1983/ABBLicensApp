using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ABBLicensApp.Annotations;
using ABBLicensApp.Model;
using License = System.ComponentModel.License;

namespace ABBLicensApp.Common
{
    public class StaticClassSingleton : INotifyPropertyChanged
    {
        private static StaticClassSingleton _instance = new StaticClassSingleton(); // part of singleton design pattern. create the instance
        private ObservableCollection<User> _usersCollection; // holds the list of user registrered Todo implent this to load all saves users from file when opening program and save when closing
        private string _currentUser;
        private Customer _selectedCustomer;
        private ObservableCollection<Customer> _customers;

        private ObservableCollection<Customer> _filteredCustomers;
        private ObservableCollection<LicensSupplier> _filteredLicenses;
        private ObservableCollection<Product> _products;
        private string _searchCustomerText;
        private string _searchLicensText;
        private ObservableCollection<LicensSupplier> _licensSupplier;
        private LicensSupplier _selectedLicensSupplier;
        private Licens _selectedLicens;
        private Product _selectedProduct;

        private StaticClassSingleton() // part of singleton. Set to private.
        {
            //NavigationClass = new Navigation(); // create the navigation class for shared use
            UsersCollection = new ObservableCollection<User>(); // create the user collection
            UsersCollection.Add(new User("admin","1234"));
            Products = new ObservableCollection<Product>();
            {
                new Licens("fdsfes", 20, DateTime.Parse("2015-10-10"), new Customer(), DateTime.Parse("2015-10-20"), new LicensSupplier());

            }
            //Licenses = new ObservableCollection<License>();
            //{
                
            //}
            Customers = new ObservableCollection<Customer>()
            {
                new Customer("Roskilde Vand Forsyning", "vandgade 12", "ros@vand.com", "22334456", "Jan"),
                new Customer("Holbæk Ild Forsyning", "ilddgade 12", "hold@ild.com", "66671122", "Torkild"),
                new Customer("Vanløse Jord Forsyning", "jordgade 12", "van@jord.com", "12341234", "Thor"),
                new Customer("Vanløse Jord Forsyning", "jordgade 12", "van@jord.com", "12341234", "Thor"),
                new Customer("Vanløse Jord Forsyning", "jordgade 12", "van@jord.com", "12341234", "Thor"),
                new Customer("Vanløse Jord Forsyning", "jordgade 12", "van@jord.com", "12341234", "Thor")
            };

            LicensSupplier = new ObservableCollection<LicensSupplier>()
            {
                new LicensSupplier("Cisco"),
                new LicensSupplier("Microsoft"),
                new LicensSupplier("McAfee")
            };
        }

        public ObservableCollection<LicensSupplier> LicensSupplier
        {
            get => _licensSupplier;
            set
            {
                if (Equals(value, _licensSupplier)) return;
                _licensSupplier = value;
                OnPropertyChanged();
            }
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                if (Equals(value, _selectedProduct)) return;
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public string SearchCustomerText
        {
            get => _searchCustomerText;
            set
            {
                if (value == _searchCustomerText) return;
                _searchCustomerText = value;
                OnPropertyChanged();
            }
        }

        public string SearchLicensText
        {
            get => _searchLicensText;
            set
            {
                if (value == _searchLicensText) return;
                _searchLicensText = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Customer> FilteredCustomers
        {
            get { return Filter.FilterValues(Customers, new CustomerNameFilter()); }
            set
            {
                if (Equals(value, _filteredCustomers)) return;
                _filteredCustomers = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<LicensSupplier> FilteredLicenses
        {
            get { return Filter.FilterValues1(LicensSupplier, new CustomerNameFilter()); }
            set
            {
                if (Equals(value, _filteredLicenses)) return;
                _filteredLicenses = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                if (Equals(value, _products)) return;
                _products = value;
                OnPropertyChanged();
            }
        }

        public LicensSupplier SelectedLicensSupplier
        {
            get => _selectedLicensSupplier;
            set
            {
                if (Equals(value, _selectedLicensSupplier)) return;
                _selectedLicensSupplier = value;
                OnPropertyChanged();
            }
        }

        public Licens SelectedLicens
        {
            get => _selectedLicens;
            set
            {
                if (Equals(value, _selectedLicens)) return;
                _selectedLicens = value;
                OnPropertyChanged();
            }
        }

        //public ObservableCollection<Licens> Licenses
        //{
        //    get => _licenses;
        //    set
        //    {
        //        if (Equals(value, _licenses)) return;
        //        _licenses = value;
        //        OnPropertyChanged();
        //    }
        //}

        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set
            {
                if (Equals(value, _customers)) return;
                _customers = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<User> UsersCollection
        {
            get => _usersCollection;
            set
            {
                if (Equals(value, _usersCollection)) return;
                _usersCollection = value;
                OnPropertyChanged();
            }
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (Equals(value, _selectedCustomer)) return;
                _selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        public string CurrentUser
        {
            get => _currentUser;
            set
            {
                if (value == _currentUser) return;
                _currentUser = value;
                OnPropertyChanged();
            }
        }

        public static StaticClassSingleton Instance // part of singleton. properties for static class.
        {
            get { return _instance; }
        }

     //   public Navigation NavigationClass { get; set; } // properties for navigation class

        

        

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
