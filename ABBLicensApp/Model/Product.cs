using System;

namespace ABBLicensApp.Model
{
    public class Product
    {
        protected string _productName;
        protected string _supplierName;
        protected DateTime _startDate;
        private int _id;

        public Product(string productName, string supplierName, DateTime startDate)
        {
            ProductName = productName;
            SupplierName = supplierName;
            StartDate = startDate;
        }

        public string ProductName { get => _productName; set => _productName = value; }
        public string SupplierName { get => _supplierName; set => _supplierName = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
    }
}