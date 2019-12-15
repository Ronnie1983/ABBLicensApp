using System;

namespace ABBLicensApp.Model
{
    public class Licens : Product
    {
        private DateTime _expireDate;
        private int _units;
        private string _licenseKey;
        private Supplier _supplier;
        
        private static string productName = "Licens";

        public Licens(string licenseKey, int units, DateTime expireDate, Customer customer, DateTime startDate, Supplier supplier) : base(productName, customer, startDate, supplier)
        {
            _supplier = supplier;
            _expireDate = expireDate;
            _units = units;
            _licenseKey = licenseKey;
        }

        public DateTime ExpireDate
        {
            get => _expireDate;
            set => _expireDate = value;
        }

        public int Units
        {
            get => _units;
            set => _units = value;
        }

        public string LicenseKey
        {
            get => _licenseKey;
            set => _licenseKey = value;
        }

        public Supplier Supplier
        {
            get => _supplier;
            set => _supplier = value;
        }
    }


}