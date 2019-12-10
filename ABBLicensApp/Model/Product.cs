using System;

namespace ABBLicensApp.Model
{
    public class Product
    {
        private string _productName;
        private string _supplierName;
        private DateTime _startDate;
        private int _id;

        public Product(string productName, string supplierName, DateTime startDate)
        {
            _productName = productName;
            _supplierName = supplierName;
            _startDate = startDate;
        }
    }
}