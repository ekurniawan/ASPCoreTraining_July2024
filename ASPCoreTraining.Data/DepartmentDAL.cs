using ASPCoreTraining.Data.Interfaces;
using ASPCoreTraining.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPCoreTraining.Data
{
    public class DepartmentDAL : IDepartmentDAL
    {
        private string _connectionString = string.Empty;
        public DepartmentDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public Department Add(Department entity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var strSql = @"INSERT INTO Departments (DepartmentName) 
                               VALUES (@DepartmentName);
                               select @@identity";
                var param = new { DepartmentName = entity.DepartmentName };
                try
                {
                    var newId = conn.ExecuteScalar(strSql, param);
                    entity.DepartmentId = Convert.ToInt32(newId);
                    return entity;
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException(sqlEx.Message);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var strSql = @"SELECT * FROM Departments
                               order by DepartmentName";
                var results = conn.Query<Department>(strSql);
                return results;
            }
        }

        public Department GetById(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var strSql = @"SELECT * FROM Departments
                               WHERE DepartmentId = @DepartmentId";
                var param = new { DepartmentId = id };
                var result = conn.QueryFirstOrDefault<Department>(strSql, param);
                return result;
            }
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
