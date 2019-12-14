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

        private void GoToAddLicense()
        {
            Navigation.GoToPage("ConnectNewLicens");
        }

        public RelayCommand LicensesBtn { get; set; }

        private void GoToLicenses()
        {
            Navigation.GoToPage("Licenses");
        }

        public void GotoCustomerList()
        {
            Navigation.GoToPage("Customers");
        }

        public RelayCommand CustomerBtn { get; set; }
    }
}
