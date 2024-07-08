using Microsoft.AspNetCore.Mvc;

namespace ASPCoreTraining.Web.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello from Employees Controller");
        }
    }
}
