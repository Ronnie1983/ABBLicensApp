using System.Collections.ObjectModel;
using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class LicensesViewModel
    {
        public LicensesViewModel()
        {
            GoBack = new RelayCommand(GoBackToMain);
            Shared = StaticClassSingleton.Instance;
            NewSupplierBtn = new RelayCommand(NewSupplierNav);
            EditSupplierBtn = new RelayCommand(EditSupplierB);
            GoToSelectedBtn = new RelayCommand(GoToLicens);
        }

        public RelayCommand GoToSelectedBtn { get; set; }

        public RelayCommand EditSupplierBtn { get; set; }

        public RelayCommand NewSupplierBtn { get; set; }

        public StaticClassSingleton Shared { get; }

        public RelayCommand GoBack { get; set; }

        public ObservableCollection<LicensSupplier> Suppliers
        {
            get => Shared.LicensSupplier;
        }

        public ObservableCollection<LicensSupplier> LicensSupplier
        {
            get => Shared.LicensSupplier;
        }

        public LicensSupplier SelectedSupplier
        {
            get => Shared.SelectedLicensSupplier;
            set => Shared.SelectedLicensSupplier = value;
        }

        private void GoToLicens()
        {
            Navigation.GoToPage("Licens");
        }

        private void GoBackToMain()
        {
            Navigation.GoBack();
        }

        private void EditSupplierB()
        {
            if (Shared.SelectedLicensSupplier != null)
            {
                Navigation.GoToPage("EditSupplier");
            }
        }

        private void NewSupplierNav()
        {
            Navigation.GoToPage("AddSupplier");
        }
    }
}
