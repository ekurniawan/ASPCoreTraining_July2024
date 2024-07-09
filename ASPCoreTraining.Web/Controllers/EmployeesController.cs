using ASPCoreTraining.Web.Models;
using ASPCoreTraining.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreTraining.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployee _employee;
        public EmployeesController(IEmployee employee)
        {
            _employee = employee;
        }

        public IActionResult Index()
        {
            var models = _employee.GetEmployees();
            return View(models);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            // Add employee to database
            _employee.AddEmployee(employee);
            return RedirectToAction("Index");
        }
    }
}
