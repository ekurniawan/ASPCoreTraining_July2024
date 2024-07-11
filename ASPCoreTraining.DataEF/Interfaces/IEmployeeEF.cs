using ASPCoreTraining.DomainEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPCoreTraining.DataEF.Interfaces
{
    public interface IEmployeeEF : ICrud<Employee>
    {
        IEnumerable<BenefitEmployee> GetEmployeeWithBenefit(string id);
    }
}
