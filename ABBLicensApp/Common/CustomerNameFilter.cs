using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Profile;
using ABBLicensApp.Model;

namespace ABBLicensApp.Common
{
    public class CustomerNameFilter : IFilterCondition
    {

        public CustomerNameFilter()
        {
            Shared = StaticClassSingleton.Instance;
        }

        public StaticClassSingleton Shared { get; set; }

        public bool Condition(Customer customer)
        {
            if (Shared.SearchCustomerText == null)
            {
                return true;
            }
            else
            {
                if (!customer.CompanyName.ToLower().Contains(Shared.SearchCustomerText.ToLower()))
                {
                    return false;
                }
            }
            

            return true;
        }

        public bool Condition1(LicensSupplier licens)
        {
            if (Shared.SearchLicensText == null)
            {
                return true;
            }
            else
            {
                if (!licens.Name.ToLower().Contains(Shared.SearchLicensText.ToLower()))
                {
                    return false;
                }
            }


            return true;
        }
    }
}
