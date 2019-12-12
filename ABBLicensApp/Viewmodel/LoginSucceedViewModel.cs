using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class LoginSucceedViewModel
    {
        public LoginSucceedViewModel()
        {
            CustomerBtn = new RelayCommand(GotoCustomerList);
        }

        public void GotoCustomerList()
        {
            Navigation.GoToPage("Customers");
        }

        public RelayCommand CustomerBtn { get; set; }
    }
}
