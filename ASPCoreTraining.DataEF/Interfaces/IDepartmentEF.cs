using ASPCoreTraining.DomainEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPCoreTraining.DataEF.Interfaces
{
    public interface IDepartmentEF : ICrud<Department>
    {
        IEnumerable<Department> GetByName(string name);
    }
}
