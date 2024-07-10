
using ASPCoreTraining.Data.Interfaces;
using ASPCoreTraining.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Oracle.ManagedDataAccess.Client;

namespace ASPCoreTraining.Data
{
    public class EmployeeDAL : IEmployeeDAL
    {
        private string _connectionString = string.Empty;
        public EmployeeDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public Employee Add(Employee entity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var strSql = @"INSERT INTO Employees (EmployeeIdMasking,FullName, Email, Department) 
                               VALUES (@EmployeeIdMasking, @FullName, @Email, @Department);
                               select @@identity";

                using (SqlCommand cmd = new SqlCommand(strSql, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeIdMasking", entity.EmployeeIdMasking);
                    cmd.Parameters.AddWithValue("@FullName", entity.FullName);
                    cmd.Parameters.AddWithValue("@Email", entity.Email);
                    cmd.Parameters.AddWithValue("@Department", entity.Department);

                    conn.Open();

                    try
                    {
                        var newId = cmd.ExecuteScalar();
                        entity.EmployeeId = Convert.ToInt32(newId);
                        return entity;
                    }
                    catch (SqlException sqlEx)
                    {
                        throw new ArgumentException($"Number: {sqlEx.Number} - Error:{sqlEx.Message}");
                    }
                }
            }
        }

        public void Delete(string id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string strSql = @"DELETE FROM Employees 
                                WHERE EmployeeIdMasking = @EmployeeIdMasking";
                using (SqlCommand cmd = new SqlCommand(strSql, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeIdMasking", id);
                    conn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException sqlEx)
                    {
                        throw new ArgumentException($"Number: {sqlEx.Number} Error: {sqlEx.Message}");
                    }
                }
            }
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
                        employee.EmployeeIdMasking = dr["EmployeeIdMasking"].ToString();
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

        public Employee GetById(string id)
        {
            Employee employee = new Employee();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string strSql = @"SELECT * FROM Employees WHERE EmployeeIdMasking = @EmployeeIdMasking";
                using (SqlCommand cmd = new SqlCommand(strSql, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeIdMasking", id);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (dr.HasRows)
                    {
                        dr.Read();
                        employee.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                        employee.EmployeeIdMasking = dr["EmployeeIdMasking"].ToString();
                        employee.FullName = dr["FullName"].ToString();
                        employee.Email = dr["Email"].ToString();
                        employee.Department = dr["Department"].ToString();
                    }
                }
            }
            return employee;
        }

        public IEnumerable<Employee> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee entity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string strSql = @"UPDATE Employees SET FullName = @FullName, Email = @Email, Department = @Department 
                                WHERE EmployeeIdMasking = @EmployeeIdMasking";
                using (SqlCommand cmd = new SqlCommand(strSql, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeIdMasking", entity.EmployeeIdMasking);
                    cmd.Parameters.AddWithValue("@FullName", entity.FullName);
                    cmd.Parameters.AddWithValue("@Email", entity.Email);
                    cmd.Parameters.AddWithValue("@Department", entity.Department);

                    conn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return entity;
                    }
                    catch (SqlException sqlEx)
                    {
                        throw new ArgumentException($"Number: {sqlEx.Number} Error: {sqlEx.Message}");
                    }
                }
            }

        }
    }
}
