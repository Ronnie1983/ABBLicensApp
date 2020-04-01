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
    public class ConnectNewLicenseViewModel : ViewModel
    {
        private string _newKey;
        private int _newUnits;
        private DateTime _expireDate;
        private DateTime _startDate = DateTime.UtcNow;
        private Licens _currentLicense;

        public ConnectNewLicenseViewModel()
        {
            Shared = StaticClassSingleton.Instance;
            GoBack = new GoBackCommand();
            CreateBtn = new ExecuteAndNavigateBackCommand(CreateLicens);
        }

        //Metoder

        private void CreateLicens()
        {
            if (NewKey != "")
            {
                _currentLicense = new Licens(NewKey, NewUnits, ExpireDate, SelectedCustomer, StartDate, SelectedLicensSupplier);

                Shared.Products.Add(_currentLicense);
            }

        }

        //Properties

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
            set => SetProperty<string>(ref _newKey, value);
        }

        public int NewUnits
        {
            get => _newUnits;
            set => SetProperty<int>(ref _newUnits, value);
        }

        public DateTime ExpireDate
        {
            get => _expireDate;
            set => SetProperty<DateTime>(ref _expireDate, value);
        }

        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty<DateTime>(ref _startDate, value);
        }

        public RelayCommand CreateBtn { get; set; }

        public RelayCommand GoBack { get; set; }

        public StaticClassSingleton Shared { get; }
    }
}
