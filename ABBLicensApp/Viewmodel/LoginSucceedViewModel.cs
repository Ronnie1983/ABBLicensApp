using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class LoginSucceedViewModel
    {
        public LoginSucceedViewModel()
        {
            CustomerBtn = new GoToPageCommand("Customers");
            LicensesBtn = new GoToPageCommand("Licenses");
            ConnectLicenseBtn = new GoToPageCommand("´ConnectNewLicense");
        }

        //Metoder

        //Properties
        public RelayCommand ConnectLicenseBtn { get; set; }
        public RelayCommand LicensesBtn { get; set; }
        public RelayCommand CustomerBtn { get; set; }

    }
}
