using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABBLicensApp.Model
{
    class ExecuteAndNavigateBackCommand : RelayCommand
    {
        public ExecuteAndNavigateBackCommand(Action execute) : base(execute){}
        public ExecuteAndNavigateBackCommand(Action execute, Func<bool> canExecute) : 
            base(execute, canExecute){}

        public override void Execute(object parameter = null)
        {
            base.Execute(parameter);
            Navigation.GoBack();
        }
    }
}
