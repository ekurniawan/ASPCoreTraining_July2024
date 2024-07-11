using ASPCoreTraining.DataEF.Interfaces;
using ASPCoreTraining.DomainEF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPCoreTraining.DataEF
{
    public class EmployeeEF : IEmployeeEF
    {
        private readonly ApplicationDbContext _db;
        public EmployeeEF(ApplicationDbContext db)
        {
            _db = db;
        }

        public Employee Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            //var results = _db.Employees.Include(e => e.Department).OrderBy(e => e.FullName);
            /*var results = from e in _db.Employees
                          join d in _db.Departments on e.DepartmentId equals d.DepartmentId
                          select new Employee
                          {
                              EmployeeId = e.EmployeeId,
                              DepartmentId = e.DepartmentId,
                              EmployeeIdMasking = e.EmployeeIdMasking,
                              FullName = e.FullName,
                              Email = e.Email,
                              Department = d
                          };*/

            var results = _db.Employees.Include(e => e.Department).OrderBy(e => e.FullName).Select(e => new Employee
            {
                EmployeeId = e.EmployeeId,
                DepartmentId = e.DepartmentId,
                EmployeeIdMasking = e.EmployeeIdMasking,
                FullName = e.FullName,
                Email = e.Email,
                Department = e.Department
            });


            return results;
        }

        public Employee GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BenefitEmployee> GetEmployeeWithBenefit(string id)
        {
            var results = _db.BenefitEmployees
                .Include(be => be.Benefit)
                .Include(be => be.Employee).ThenInclude(e => e.Department)
                .Where(be => be.Employee.EmployeeIdMasking == id);
            return results;
        }

        public Employee Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
