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

        public StaticClassSingleton Shared { get; set; }

        public RelayCommand GoBackBtn { get; set; }

        public RelayCommand EditBtn { get; set; }

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

        private void Cancel()
        {
            Navigation.GoBack();
        }

        private void EditMethod()
        {
            foreach (var a in Shared.LicensSupplier)
            {
                if (a.Name == Shared.SelectedLicensSupplier.Name)
                {
                    a.Name = Name;
                }
            }

            Navigation.GoToPage("Licenses");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
