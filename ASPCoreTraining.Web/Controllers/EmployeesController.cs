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
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            var models = _employee.GetEmployees();
            return View(models);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            try
            {
                var result = _employee.GetEmployeeById(id);
                return View(result);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            // Add employee to database
            _employee.AddEmployee(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var employee = _employee.GetEmployeeById(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            _employee.UpdateEmployee(employee);
            TempData["Message"] = "Employee updated successfully";

            return RedirectToAction("Index");
        }
    }
}
