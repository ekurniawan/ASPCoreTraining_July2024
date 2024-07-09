using ASPCoreTraining.Web.Models;

namespace ASPCoreTraining.Web.Services
{
    public interface IEmployee
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
