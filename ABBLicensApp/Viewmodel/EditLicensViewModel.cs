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
    public class EditLicensViewModel : ViewModel
    {
        private Licens _originalLicense;
        private ObservableCollection<Product> _ProductListAtSupplier = new ObservableCollection<Product>();

        public EditLicensViewModel()
        {
            Shared = StaticClassSingleton.Instance;
            GoBackBtn = new GoBackCommand();
            ChanceBtn = new RelayCommand(SaveChangesAndGoBack);
            _originalLicense = Shared.SelectedLicens;
        }

        //Metoder
        private void SaveChangesAndGoBack()
        {
            for (int i = 0; i < Shared.Products.Count; i++)
            {
                Product p = Shared.Products[i];
                Licens l = (Licens)p;
                if (l.LicenseKey == _originalLicense.LicenseKey)
                {
                    Shared.Products[i] = SelectedLicense;

                    //l.LicenseKey = LicenseKey;
                    //l.ExpireDate = ExpireDate;
                    //l.Units = Units;
                    //c.StartDate = StartDate;
                }
            }
            Navigation.GoBack();
        }

        //Properties


        public Product SelectedProduct
        {
            get { return Shared.SelectedProduct; }
            set { Shared.SelectedProduct = value; }
        }

        public Licens SelectedLicense
        {
            get { return Shared.SelectedLicens; }
            set { Shared.SelectedLicens = value; }
        }

        public DateTime ExpireDate
        {
            get => Shared.SelectedLicens.ExpireDate;
            set
            {
                DateTime expire = SelectedLicense.ExpireDate;
                SetProperty<DateTime>(ref expire, value);
            }
        }

        public DateTime StartDate
        {
            get => Shared.SelectedLicens.StartDate;
            set
            {
                DateTime start = SelectedLicense.StartDate;
                SetProperty<DateTime>(ref start, value);
            }
        }

        public int Units
        {
            get => Shared.SelectedLicens.Units;
            set
            {
                int units = SelectedLicense.Units;
                SetProperty<int>(ref units, value);
            }
        }

        public string LicenseKey
        {
            get => Shared.SelectedLicens.LicenseKey;
            set
            {
                string key = SelectedLicense.LicenseKey;
                SetProperty<string>(ref key, value);
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

        public RelayCommand ChanceBtn { get; set; }
        public RelayCommand GoBackBtn { get; set; }
        public StaticClassSingleton Shared { get; }
    }
}
