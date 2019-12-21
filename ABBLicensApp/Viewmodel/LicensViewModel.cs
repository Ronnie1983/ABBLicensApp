using ABBLicensApp.Annotations;
using ABBLicensApp.Common;
using ABBLicensApp.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ABBLicensApp.Viewmodel
{
    public class LicensViewModel : ViewModel
    {
        ObservableCollection<Product> _newList = new ObservableCollection<Product>();

        public LicensViewModel()
        {
            GoBack = new GoBackCommand();
            DeleteBtn = new RelayCommand(Delete);
            ChanceBtn = new RelayCommand(Change);
            EditSupplierBtn = new RelayCommand(EditSupplier);
            Shared = StaticClassSingleton.Instance;
            SelectedLicens = null;
        }

        //Metoder

        private void Delete()
        {
            Shared.Products.Remove(SelectedLicens);
            NewList.Clear();
            OnPropertyChanged(nameof(NewList));
        }

        private void EditSupplier()
        {
            if (Shared.SelectedLicensSupplier != null)
            {
                Navigation.GoToPage("EditSupplier");
            }
        }

        private void Change()
        {
            if (SelectedLicens != null)
            {
                Navigation.GoToPage("EditLicens");
            }
        }

        //Properties

        public LicensSupplier SelectedLicensSupplier
        {
            get => Shared.SelectedLicensSupplier;
            set => Shared.SelectedLicensSupplier = value;
        }

        public Licens SelectedLicens
        {
            get => Shared.SelectedLicens;
            set => Shared.SelectedLicens = value;
        }

        public ObservableCollection<Product> NewList
        {
            get
            {
                foreach (Product a in Shared.Products)
                {
                    if (a.Supplier == SelectedLicensSupplier)
                    {
                        _newList.Add(a);
                    }
                }
                return _newList;
            }
            set
            {
                SetProperty<ObservableCollection<Product>>(ref _newList, value);
            }
        }

        public RelayCommand EditSupplierBtn { get; set; }
        public RelayCommand ChanceBtn { get; set; }
        public RelayCommand GoBack { get; set; }
        public RelayCommand DeleteBtn { get; set; }
        public StaticClassSingleton Shared { get; }
    }
}
