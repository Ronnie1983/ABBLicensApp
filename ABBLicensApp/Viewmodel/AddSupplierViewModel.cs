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
            GoBackBtn = new RelayCommand(CancelBtn);
            Shared = StaticClassSingleton.Instance;
        }

        public RelayCommand AddSupplierBtn { get; set; }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public StaticClassSingleton Shared { get; }

        public RelayCommand GoBackBtn { get; set; }

        private void CancelBtn()
        {
            Navigation.GoBack();
        }

        public void AddBtn()
        {
            Shared.Suppliers.Add(new Supplier(Name));
            Navigation.GoBack();
        }
    }
}
