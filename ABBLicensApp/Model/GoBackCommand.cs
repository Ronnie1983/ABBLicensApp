using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABBLicensApp.Model
{
    class GoBackCommand : RelayCommand
    {
        public GoBackCommand() : base(Navigation.GoBack) { }
        public GoBackCommand(Func<bool> canRun) : base(Navigation.GoBack, canRun) { }
    }
}
