using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    class CustomerViewModel
    {
        private Customer _customer;

        public CustomerViewModel()
        {
            Shared = StaticClassSingleton.Instance;
            Customer = Shared.SelectedCustomer;
        }

        public StaticClassSingleton Shared { get; }
        
        public Customer Customer 
        { 
            get => _customer; 
            set => _customer = value; 
        }
    }


}
