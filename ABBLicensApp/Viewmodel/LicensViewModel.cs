using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Profile;
using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class LicensViewModel
    {

        public LicensViewModel()
        {
            GoBack = new RelayCommand(GoBackOne);
            Shared = StaticClassSingleton.Instance;
        }

        public StaticClassSingleton Shared { get; }

        public Supplier SelectedSupplier
        {
            get => Shared.SelectedSupplier;
            set => Shared.SelectedSupplier = value;
        }

        public License SelectedLicense { get; set; }

        public RelayCommand GoBack { get; set; }

        private void GoBackOne()
        {
            Navigation.GoBack();
        }
    }
}
