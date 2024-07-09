using ASPCoreTraining.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPCoreTraining.Data.Interfaces
{
    public interface IEmployeeDAL : ICrud<Employee>
    {
        IEnumerable<Employee> GetByName(string name);
    }
}
