using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class CustomerViewModel
    {
        private Customer _customer;

        public CustomerViewModel()
        {
            Shared = StaticClassSingleton.Instance;
            Customer = Shared.SelectedCustomer;
            Customer.Products = new List<Product>
            {
                new Product("KSJDLKASJDKLASD", "McAfee", new DateTime(2015, 10, 20)),
                new Product("SDJAKLSD-weqewqe", "Windows", new DateTime(2013, 12, 1)),
                new Product("KSJDLKASJDKLASD", "Cisco", new DateTime(2016, 7, 14))
            };
        }

        public StaticClassSingleton Shared { get; }
        
        public Customer Customer 
        { 
            get => _customer; 
            set => _customer = value; 
        }


    }


}
