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
        private ObservableCollection<License> _licenses;
        private ObservableCollection<Supplier> _suppliers;
        private Supplier _selectedSupplier;

        private StaticClassSingleton() // part of singleton. Set to private.
        {
            //NavigationClass = new Navigation(); // create the navigation class for shared use
            UsersCollection = new ObservableCollection<User>(); // create the user collection
            UsersCollection.Add(new User("admin","1234"));
            _customers = new ObservableCollection<Customer>()
            {
                new Customer("Roskilde Vand Forsyning", "vandgade 12", "ros@vand.com", "22334456", "Jan"),
                new Customer("Holbæk Ild Forsyning", "ilddgade 12", "hold@ild.com", "66671122", "Torkild"),
                new Customer("Vanløse Jord Forsyning", "jordgade 12", "van@jord.com", "12341234", "Thor"),
                new Customer("Vanløse Jord Forsyning", "jordgade 12", "van@jord.com", "12341234", "Thor"),
                new Customer("Vanløse Jord Forsyning", "jordgade 12", "van@jord.com", "12341234", "Thor"),
                new Customer("Vanløse Jord Forsyning", "jordgade 12", "van@jord.com", "12341234", "Thor")
            };
            Suppliers = new ObservableCollection<Supplier>()
            {
                new Supplier("McAfee"),
                new Supplier("Cisco"),
                new Supplier("Microsoft")
            };
        }

        public Supplier SelectedSupplier
        {
            get => _selectedSupplier;
            set
            {
                if (Equals(value, _selectedSupplier)) return;
                _selectedSupplier = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Supplier> Suppliers
        {
            get => _suppliers;
            set
            {
                if (Equals(value, _suppliers)) return;
                _suppliers = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<License> Licenses
        {
            get => _licenses;
            set
            {
                if (Equals(value, _licenses)) return;
                _licenses = value;
                OnPropertyChanged();
            }
        }

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
