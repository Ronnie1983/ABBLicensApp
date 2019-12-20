using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class AddSupplierViewModel
    {
        private string _name;

        public AddSupplierViewModel()
        {
            AddSupplierBtn = new RelayCommand(AddBtn);
            GoBackBtn = new GoBackCommand();
            Shared = StaticClassSingleton.Instance;
        }
        
        //Metoder
        
        public void AddBtn()
        {
            Shared.LicensSupplier.Add(new LicensSupplier(Name));
            Navigation.GoBack();
        }

        //Properties

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public RelayCommand AddSupplierBtn { get; set; }

        public StaticClassSingleton Shared { get; }

        public RelayCommand GoBackBtn { get; set; }

        
    }
}
