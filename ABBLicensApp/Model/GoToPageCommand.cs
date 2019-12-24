using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABBLicensApp.Model
{
    class GoToPageCommand : RelayCommand
    {
        public GoToPageCommand(String page): base(() => Navigation.GoToPage(page)) { }
        public GoToPageCommand(String page, Func<bool> canRun): base(() => Navigation.GoToPage(page), canRun) { }
    }
}
