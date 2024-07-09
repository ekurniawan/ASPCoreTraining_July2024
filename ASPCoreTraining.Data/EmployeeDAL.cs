﻿
using ASPCoreTraining.Data.Interfaces;
using ASPCoreTraining.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Oracle.ManagedDataAccess.Client;

namespace ASPCoreTraining.Data
{
    public class EmployeeDAL : IEmployeeDAL
    {
        private string _connectionString = @"Data Source=ACTUAL;Initial Catalog=KangeanDb;Integrated Security=True;TrustServerCertificate=True";

        public Employee Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var strSql = "SELECT * FROM Employees";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var employee = new Employee();
                        employee.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                        employee.FullName = dr["FullName"].ToString();
                        employee.Email = dr["Email"].ToString();
                        employee.Department = dr["Department"].ToString();

                        employees.Add(employee);
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();

                return employees;
            }
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
