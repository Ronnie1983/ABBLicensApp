using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ABBLicensApp.Annotations;
using ABBLicensApp.Common;
using ABBLicensApp.Model;
using Licens = ABBLicensApp.Model.Licens;

namespace ABBLicensApp.Viewmodel
{
    public class ConnectNewLicenseViewModel : INotifyPropertyChanged
    {
        private string _newKey;
        private int _newUnits;
        private DateTime _expireDate;
        private DateTime _startDate;
        private Licens _currentLicense;

        public ConnectNewLicenseViewModel()
        {
            Shared = StaticClassSingleton.Instance;
            GoBack = new RelayCommand(GoBackHistory);
            CreateBtn = new RelayCommand(CreateLicens);
        }

        public RelayCommand CreateBtn { get; set; }

        private void CreateLicens()
        {
            // ToDo Add customer to supplier
            // ToDo Add License to Customer
            _currentLicense = new Licens(NewKey, NewUnits, ExpireDate, SelectedCustomer, StartDate, SelectedLicensSupplier);

            Shared.Products.Add(_currentLicense);
            Navigation.GoBack();
        }

        public RelayCommand GoBack { get; set; }

        private void GoBackHistory()
        {
            Navigation.GoBack();
        }

        public StaticClassSingleton Shared { get; }

        public ObservableCollection<LicensSupplier> LicensSupplier
        {
            get => Shared.LicensSupplier;
            set => Shared.LicensSupplier = value;
        }

        public ObservableCollection<Customer> Customers
        {
            get => Shared.Customers;
            set => Shared.Customers = value;
        }

        public Customer SelectedCustomer
        {
            get => Shared.SelectedCustomer;
            set
            {
                Shared.SelectedCustomer = value;
                OnPropertyChanged();
            }
        }

        public LicensSupplier SelectedLicensSupplier
        {
            get => Shared.SelectedLicensSupplier;
            set
            {
                Shared.SelectedLicensSupplier = value;
                OnPropertyChanged();
            }
        }

        public string NewKey
        {
            get => _newKey;
            set => _newKey = value;
        }

        public int NewUnits
        {
            get => _newUnits;
            set => _newUnits = value;
        }

        public DateTime ExpireDate
        {
            get => _expireDate;
            set => _expireDate = value;
        }

        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
