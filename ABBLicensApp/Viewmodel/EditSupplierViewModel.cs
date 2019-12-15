using System.ComponentModel;
using System.Runtime.CompilerServices;
using ABBLicensApp.Annotations;
using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class EditSupplierViewModel : INotifyPropertyChanged
    {
        private string _name;

        public EditSupplierViewModel()
        {
            Shared = StaticClassSingleton.Instance;
            EditBtn = new RelayCommand(EditMethod);
            _name = Shared.SelectedLicensSupplier.Name;
            GoBackBtn = new RelayCommand(Cancel);
        }

        public RelayCommand GoBackBtn { get; set; }

        private void Cancel()
        {
            Navigation.GoBack();
        }

        public RelayCommand EditBtn { get; set; }

        private void EditMethod()
        {
            //Shared.Suppliers.Where((supplier) => supplier.Name == Shared.SelectedSupplier.Name);
            foreach (var a in Shared.LicensSupplier)
            {
                if (a.Name == Shared.SelectedLicensSupplier.Name)
                {
                    a.Name = Name;
                }
            }

            Navigation.GoToPage("Licenses");
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public StaticClassSingleton Shared { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
