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
                new License(DateTime.Parse("2015-10-20"), DateTime.Parse("2020-01-01"), 100, "KSJDLKASJDKLASD", "McAfee"),
                new License(DateTime.Parse("2013-12-01"), DateTime.Parse("2020-01-15"), 50, "SDJAKLSD-weqewqe", "Windows"),
                new License(DateTime.Parse("2016-07-14"), DateTime.Parse("2022-12-18"), 20, "KSJDLKASJDKLASD", "Cisco")
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
