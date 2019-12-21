using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ABBLicensApp.Annotations;
using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class LicensesViewModel : ViewModel
    {
        public LicensesViewModel()
        {
            GoBack = new GoToPageCommand("LoginSucceed");
            Shared = StaticClassSingleton.Instance;
            NewSupplierBtn = new GoToPageCommand("AddSupplier");
            SelectedSupplier = null;
        }

        //Metoder

        //Properties

        public ObservableCollection<LicensSupplier> Suppliers
        {
            get => Shared.LicensSupplier;
        }

        public string SearchLicensText
        {
            get { return Shared.SearchLicensText; }
            set
            {
                Shared.SearchLicensText = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<LicensSupplier> LicensSupplier
        {
            get => Shared.LicensSupplier;
        }

        public ObservableCollection<LicensSupplier> FilteredLicensSupplier
        {
            get => Shared.FilteredLicenses;
        }

        public LicensSupplier SelectedSupplier
        {
            get => Shared.SelectedLicensSupplier;
            set
            {
                Shared.SelectedLicensSupplier = value;
                if (SelectedSupplier != null)
                {
                    Navigation.GoToPage("Licens");
                }
                
            } 
        }

        public RelayCommand NewSupplierBtn { get; set; }
        public StaticClassSingleton Shared { get; }
        public RelayCommand GoBack { get; set; }
    }
}
