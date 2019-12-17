using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using Windows.UI.Xaml.Controls;
using ABBLicensApp.Annotations;
using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class EditLicensViewModel : INotifyPropertyChanged
    {
        private DateTime _expireDate;
        private DateTime _startDate;
        private int _units;
        private string _licenseKey;
        private ObservableCollection<Product> _ProductListAtSupplier = new ObservableCollection<Product>();

        public EditLicensViewModel()
        {
            Shared = StaticClassSingleton.Instance;
            GoBackBtn = new RelayCommand(GoBack);
            ChanceBtn = new RelayCommand(Chance);
        }

        public RelayCommand ChanceBtn { get; set; }

        public RelayCommand GoBackBtn { get; set; }

        public StaticClassSingleton Shared { get; }

        public Product SelectedProduct
        {
            get { return Shared.SelectedProduct; }
            set { Shared.SelectedProduct = value; }
        }

        public DateTime ExpireDate
        {
            get => _expireDate;
            set
            {
                if (value.Equals(_expireDate)) return;
                _expireDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (value.Equals(_startDate)) return;
                _startDate = value;
                OnPropertyChanged();
            }
        }

        public int Units
        {
            get => _units;
            set
            {
                if (value == _units) return;
                _units = value;
                OnPropertyChanged();
            }
        }

        public string LicenseKey
        {
            get => _licenseKey;
            set
            {
                if (value == _licenseKey) return;
                _licenseKey = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Product> ProductList
        {
            get 
            {
                _ProductListAtSupplier.Clear();
                foreach (var p in Shared.Products)
                {
                    if (p.Supplier.Name == Shared.SelectedLicensSupplier.Name)
                    {
                        _ProductListAtSupplier.Add(p);
                    }
                }

                return _ProductListAtSupplier;
            }
        }

        private void Chance()
        {
            foreach (var c in Shared.Products)
            {

                Licens l = (Licens) c;
                if (l.LicenseKey == Shared.SelectedLicens.LicenseKey)
                {
                    l.LicenseKey = LicenseKey;
                    l.ExpireDate = ExpireDate;
                    l.Units = Units;
                    c.StartDate = StartDate;
                }
            }
            Navigation.GoBack();
        }

        private void GoBack()
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
