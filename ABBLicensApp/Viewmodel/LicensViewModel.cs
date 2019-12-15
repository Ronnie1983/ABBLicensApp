using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ABBLicensApp.Annotations;
using ABBLicensApp.Common;
using ABBLicensApp.Model;
using ABBLicensApp.View;
using Licens = ABBLicensApp.Model.Licens;

namespace ABBLicensApp.Viewmodel
{
    public class LicensViewModel : INotifyPropertyChanged
    {
        private Product _selectedLicense;
        ObservableCollection<Product> _newList = new ObservableCollection<Product>();

        public LicensViewModel()
        {
            GoBack = new RelayCommand(GoBackOne);
            DeleteBtn = new RelayCommand(DeleteMethod);
            Shared = StaticClassSingleton.Instance;
        }

        public RelayCommand DeleteBtn { get; set; }

        private void DeleteMethod()
        {
            Shared.Products.Remove(SelectedLicens);
            NewList.Clear();
            OnPropertyChanged(nameof(NewList));
        }

        public StaticClassSingleton Shared { get; }

        public LicensSupplier SelectedLicensSupplier
        {
            get => Shared.SelectedLicensSupplier;
            set => Shared.SelectedLicensSupplier = value;
        }

        public Product SelectedLicens
        {
            get => _selectedLicense;
            set => _selectedLicense = value;
        }

        public RelayCommand GoBack { get; set; }

        private void GoBackOne()
        {
            Navigation.GoBack();
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
                if (Equals(value, _newList)) return;
                _newList = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
