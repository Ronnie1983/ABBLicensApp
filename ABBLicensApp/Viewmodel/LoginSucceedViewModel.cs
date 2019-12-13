using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABBLicensApp.Model;
using ABBLicensApp.View;

namespace ABBLicensApp.Viewmodel
{
    public class LoginSucceedViewModel
    {
        public LoginSucceedViewModel()
        {
            CustomerBtn = new RelayCommand(GotoCustomerList);
            LicensesBtn = new RelayCommand(GoToLicenses);
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
