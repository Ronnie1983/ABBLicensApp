using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Profile;
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
            _name = Shared.SelectedSupplier.Name;
            GoBack = new RelayCommand(Cancel);
        }

        public RelayCommand GoBack { get; set; }

        private void Cancel()
        {
            Navigation.GoBack();
        }

        public RelayCommand EditBtn { get; set; }

        private void EditMethod()
        {
            Shared.Suppliers.Remove(Shared.SelectedSupplier);
            Shared.Suppliers.Add(new Supplier(Name));
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
