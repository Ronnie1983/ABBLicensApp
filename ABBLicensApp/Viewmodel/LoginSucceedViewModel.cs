using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class LoginSucceedViewModel
    {
        public LoginSucceedViewModel()
        {
            CustomerBtn = new RelayCommand(GotoCustomerList);
            LicensesBtn = new RelayCommand(GoToLicenses);
            ConnectLicenseBtn = new RelayCommand(GoToAddLicense);
        }

        public RelayCommand ConnectLicenseBtn { get; set; }

        public RelayCommand LicensesBtn { get; set; }

        public RelayCommand CustomerBtn { get; set; }

        private void GoToAddLicense()
        {
            Navigation.GoToPage("ConnectNewLicens");
        }

        private void GoToLicenses()
        {
            Navigation.GoToPage("Licenses");
        }

        public void GotoCustomerList()
        {
            Navigation.GoToPage("Customers");
        }
    }
}
