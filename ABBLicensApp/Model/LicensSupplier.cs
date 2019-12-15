using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Profile;
using ABBLicensApp.Common;

namespace ABBLicensApp.Model
{
    public class LicensSupplier : Supplier
    {
        //private ObservableCollection<Licens> _licensAtSupplier = new ObservableCollection<Licens>();

        public LicensSupplier(string name) : base(name)
        {
            Type = "Licens";
            
        }

        public LicensSupplier()
        {
            Type = "Licens";
        }

        //public ObservableCollection<Licens> Licenses
        //{
        //    get => ;
        //    set
        //    {
        //        if (Equals(value, _licensAtSupplier)) return;
        //        _licensAtSupplier = value;
        //        OnPropertyChanged();
        //    }
        //}

        public string Type { get; set; }
    }
}
