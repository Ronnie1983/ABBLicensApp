using System;
using System.Collections.ObjectModel;

namespace ABBLicensApp.Model
{
    public class Product
    {
        protected string _productName;
        protected Customer _customer;
        protected DateTime _startDate;
        private Supplier _supplier;
        private int _id;
        private ObservableCollection<Customer> _customersAtProducts = new ObservableCollection<Customer>();

        public Product(string productName, Customer customer, DateTime startDate, Supplier supplier)
        {
            Supplier = supplier;
            ProductName = productName;
            Customer = customer;
            StartDate = startDate;
        }

        public string ProductName { get => _productName; set => _productName = value; }
        public Customer Customer { get => _customer; set => _customer = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }

        public Supplier Supplier
        {
            get => _supplier;
            set => _supplier = value;
        }

        //public virtual string GetLicensKey
        //{
        //    get
        //    {
        //        return "";
        //    }
           
        //}

        public virtual DateTime GetExpireDate
        {
            get { return Convert.ToDateTime(""); }
        }

        public virtual int GetUnits
        {
            get => 1;
        }
    }
}