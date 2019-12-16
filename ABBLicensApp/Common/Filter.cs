using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABBLicensApp.Model;

namespace ABBLicensApp.Common
{
    public static class Filter
    {
        public static ObservableCollection<Customer> FilterValues(ObservableCollection<Customer> customers,
            IFilterCondition ifc)
        {
            ObservableCollection<Customer> fileredValues = new ObservableCollection<Customer>();

            foreach (Customer costumer in customers)
            {
                if (ifc.Condition(costumer))
                {
                    fileredValues.Add(costumer);
                }
            }

            return fileredValues;
        }
    }
}
