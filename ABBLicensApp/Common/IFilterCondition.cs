using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABBLicensApp.Model;

namespace ABBLicensApp.Common
{
    public interface IFilterCondition
    {
        bool Condition(Customer customer);
        bool Condition1(LicensSupplier licens);
    }
}
