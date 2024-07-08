using ASPCoreTraining.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreTraining.Web.Controllers
{
    public class EmployeesController : Controller
    {


        public IActionResult Index()
        {
            return View(employees);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            // Add employee to database
            employees.Add(employee);

            return RedirectToAction("Index");
        }
    }
}
