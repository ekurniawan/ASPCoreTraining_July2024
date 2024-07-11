using ASPCoreTraining.DataEF.Interfaces;
using ASPCoreTraining.DomainEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPCoreTraining.DataEF
{
    public class DepartmentEF : IDepartmentEF
    {
        private readonly ApplicationDbContext _db;
        public DepartmentEF(ApplicationDbContext db)
        {
            _db = db;
        }

        public Department Add(Department entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAll()
        {
            var results = _db.Departments.OrderBy(d => d.DepartmentName);
            /*var results = from d in _db.Departments
                          select d;*/
            return results;
        }

        public Department GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Department Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
