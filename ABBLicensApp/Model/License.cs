using System;

namespace ABBLicensApp.Model
{
    public class License : Product
    {
        private DateTime _expireDate;
        private int _units;
        private string _licenseKey;
        
        public License(DateTime startDate, DateTime expireDate, int units, string licenseKey, string supplierName)
        :base("License", supplierName, startDate)
        {
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
    }


}