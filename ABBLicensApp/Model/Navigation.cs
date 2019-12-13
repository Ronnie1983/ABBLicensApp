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
    static public class Navigation
    {

        static public void GoToPage(string dest, object param = null)
        {
            Frame rootFrame = getRootFrame();
            Type type = getPageType(dest);

            if (param == null)
            {
                rootFrame.Navigate(type);
            }
            else
            {
                rootFrame.Navigate(type, param);
            }
        }

        static public void GoBack()
        {
            Frame rootFrame = getRootFrame();

            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
        }


        static private Frame getRootFrame()
        {
            return Window.Current.Content as Frame;
        }


        static private Type getPageType(string page, string pageNameSpace= "ABBLicensApp.View")
        {
            Type type = Type.GetType(pageNameSpace + "." + page);

            return type;
        }


    }
}
