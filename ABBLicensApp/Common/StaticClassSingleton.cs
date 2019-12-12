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

namespace ABBLicensApp.Common
{
    public class StaticClassSingleton : INotifyPropertyChanged
    {
        private static StaticClassSingleton _instance = new StaticClassSingleton(); // part of singleton design pattern. create the instance
        private ObservableCollection<User> _usersCollection; // holds the list of user registrered Todo implent this to load all saves users from file when opening program and save when closing
        private string _currentUser;
        private Customer _selectedCustomer;

        private StaticClassSingleton() // part of singleton. Set to private.
        {
            NavigationClass = new Navigation(); // create the navigation class for shared use
            UsersCollection = new ObservableCollection<User>(); // create the user collection
            UsersCollection.Add(new User("admin","1234"));
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

        public Navigation NavigationClass { get; set; } // properties for navigation class

        

        

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
