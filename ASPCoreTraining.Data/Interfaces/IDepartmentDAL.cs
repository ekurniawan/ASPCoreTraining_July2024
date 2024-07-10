using ASPCoreTraining.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPCoreTraining.Data.Interfaces
{
    public interface IDepartmentDAL : ICrud<Department>
    {
        IEnumerable<Department> GetByName(string name);
    }
}
