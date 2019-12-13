using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Profile;
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
            Navigation.GoToPage("LoginSucceed");
        }

        public ObservableCollection<Supplier> Suppliers
        {
            get => Shared.Suppliers;
        }

        public Supplier SelectedSupplier
        {
            get => Shared.SelectedSupplier;
            set => Shared.SelectedSupplier = value;
        }
    }
}
