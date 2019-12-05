using System;

namespace ABBLicensApp.Model
{
    public class License : Product
    {
        private DateTime _expireDate;
        private int _units;
        private string _licenseKey;
    }
}