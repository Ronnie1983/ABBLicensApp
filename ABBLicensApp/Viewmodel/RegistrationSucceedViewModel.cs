using ABBLicensApp.Common;
using ABBLicensApp.Model;

namespace ABBLicensApp.Viewmodel
{
    public class RegistrationSucceedViewModel : ViewModel
    {
        public RegistrationSucceedViewModel()
        {
            Shared = StaticClassSingleton.Instance;
            GoToMainPageOk = new GoToPageCommand("MainPage");
        }

        //Metoder

        //Properties

        public StaticClassSingleton Shared { get; private set; }
        public RelayCommand GoToMainPageOk { get; set; }

    }
}
