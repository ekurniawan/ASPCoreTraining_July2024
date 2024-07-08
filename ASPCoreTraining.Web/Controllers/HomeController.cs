using Microsoft.AspNetCore.Mvc;

namespace ASPCoreTraining.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello from Home Controller");
        }

        public IActionResult About()
        {
            return Content("Hello from About Controller");
        }
    }
}
