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
    public class DepartmentEF : IDepartmentEF
    {
        private readonly ApplicationDbContext _db;
        public DepartmentEF(ApplicationDbContext db)
        {
            _db = db;
        }

        public Department Add(Department entity)
        {
            try
            {
                _db.Departments.Add(entity);

                _db.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Delete(string id)
        {
            try
            {
                var deleteDepartment = GetById(id);
                _db.Departments.Remove(deleteDepartment);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Department> GetAll()
        {
            //raw sql
            var results = _db.Departments.FromSqlRaw("SP_GetAllDepartments").ToList();
            //var results = _db.Departments.OrderBy(d => d.DepartmentName);
            /*var results = from d in _db.Departments
                          select d;*/
            return results;
        }

        public Department GetById(string id)
        {
            //var result = _db.Departments.Where(d => d.DepartmentId == Convert.ToInt32(id)).FirstOrDefault();

            //sql raw interpolation
            var result = _db.Departments.FromSqlInterpolated($"SELECT * FROM Departments WHERE DepartmentId = {id}").FirstOrDefault();

            if (result == null)
            {
                throw new ArgumentException("Department not found");
            }
            return result;
        }

        public IEnumerable<Department> GetByName(string name)
        {
            var results = _db.Departments.Where(d => d.DepartmentName.ToLower().Contains(name.ToLower())).OrderBy(d => d.DepartmentName);
            return results;
        }

        public Department Update(Department entity)
        {
            var updateDepartment = GetById(entity.DepartmentId.ToString());
            if (updateDepartment == null)
            {
                throw new ArgumentException("Department not found");
            }
            try
            {
                updateDepartment.DepartmentName = entity.DepartmentName;
                _db.SaveChanges();
                return updateDepartment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
