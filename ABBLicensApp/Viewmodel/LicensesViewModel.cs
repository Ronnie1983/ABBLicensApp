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

        private void GoToLicens()
        {
            Navigation.GoToPage("Licens");
        }

        public RelayCommand EditSupplierBtn { get; set; }

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

        public RelayCommand NewSupplierBtn { get; set; }

        public StaticClassSingleton Shared { get; }


        public RelayCommand GoBack { get; set; }

        private void GoBackToMain()
        {
            Navigation.GoBack();
        }

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
    }
}
