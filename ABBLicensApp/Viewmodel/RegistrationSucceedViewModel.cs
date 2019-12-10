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
    public class RegistrationSucceedViewModel
    {
        public RegistrationSucceedViewModel()
        {
            Shared = StaticClassSingleton.Instance;
            GoToMainPageOk = new RelayCommand(MainPageButton);
        }

        public StaticClassSingleton Shared { get; private set; }

        public RelayCommand GoToMainPageOk { get; set; }

        private void MainPageButton()
        {
            Navigation.GoToPage("MainPage");
        }
    }
}
