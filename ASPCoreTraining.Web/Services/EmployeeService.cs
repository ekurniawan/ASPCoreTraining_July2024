using ASPCoreTraining.Web.Models;

namespace ASPCoreTraining.Web.Services
{
    public class EmployeeService : IEmployee
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { EmployeeId = 1, FullName = "Eko Kurniawan", Email = "eko@gmail.com",Department="IT", Address="Jakarta" },
            new Employee { EmployeeId = 2, FullName = "John Doe", Email = "jhon@gmail.com",Department="HR", Address="Bandung" },
            new Employee { EmployeeId = 3, FullName = "Jane Doe", Email = "jane@gmail.com",Department="Finance", Address="Surabaya" }
        };

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = employees.SingleOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
