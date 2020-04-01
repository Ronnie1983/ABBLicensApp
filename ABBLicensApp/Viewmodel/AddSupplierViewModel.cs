using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class AddSupplierViewModel : ViewModel
    {
        private string _name;

        public AddSupplierViewModel()
        {
            AddSupplierBtn = new ExecuteAndNavigateBackCommand(AddSupplier);
            GoBackBtn = new GoBackCommand();
            Shared = StaticClassSingleton.Instance;
        }
        
        //Metoder
        
        public void AddSupplier()
        {
            Shared.LicensSupplier.Add(new LicensSupplier(Name));
        }

        //Properties

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public RelayCommand AddSupplierBtn { get; set; }

        public StaticClassSingleton Shared { get; }

        public RelayCommand GoBackBtn { get; set; }

        
    }
}
