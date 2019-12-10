using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ABBLicensApp.View;
using Microsoft.Xaml.Interactions.Core;

namespace ABBLicensApp.Model
{
    public class Navigation : Page
    {
        public void RegistrationButtonNavigation()
        {
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(RegisterPage));
        }

        public void LoginButtonNavigation()
        {
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(LoginSucceed));
        }

        public void GoToRegistrationSucceedButtonNavigation()
        {
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(registrationSucceed));
        }

        public void GoToMainPage()
        {
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage));
        }

    }
}
