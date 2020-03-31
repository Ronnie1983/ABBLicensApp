using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class AddSupplierViewModel : ViewModel
    {
        private string _name;

        public AddSupplierViewModel()
        {
            AddSupplierBtn = new RelayCommand(AddSupplierAndGoBack);
            GoBackBtn = new GoBackCommand();
            Shared = StaticClassSingleton.Instance;
        }
        
        //Metoder
        
        public void AddSupplierAndGoBack()
        {
            Shared.LicensSupplier.Add(new LicensSupplier(Name));
            Navigation.GoBack();
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
