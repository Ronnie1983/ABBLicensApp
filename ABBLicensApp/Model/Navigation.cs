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
    public class Navigation
    {
        static public void GoToPage(string dest, object param = null)
        {
            string pageNamespace = "ABBLicensApp.View";
            var rootFrame = Window.Current.Content as Frame;
            Type type = Type.GetType(pageNamespace + "." + dest);

            if (param == null)
            {
                rootFrame.Navigate(type);
            }
            else
            {
                rootFrame.Navigate(type, param);
            }
        }


    }
}
