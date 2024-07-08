using Microsoft.AspNetCore.Mvc;

namespace ASPCoreTraining.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //ViewData["username"] = "ekurniawan";
            ViewBag.username = "ekurniawan";

            List<string> users = new List<string>();
            users.Add("ekurniawan");
            users.Add("johndoe");
            users.Add("janedoe");
            ViewBag.users = users;

            return View();
        }

        public IActionResult About()
        {
            return Content("Hello from About Controller");
        }
    }
}
