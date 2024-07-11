using ASPCoreTraining.DataEF.Interfaces;
using ASPCoreTraining.DomainEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreTraining.WebWithTemplate.Controllers
{
    public class DepartmentsEFController : Controller
    {
        private readonly IDepartmentEF _departmentEF;
        public DepartmentsEFController(IDepartmentEF departmentEF)
        {
            _departmentEF = departmentEF;
        }
        // GET: DepartmentsEFController
        public ActionResult Index()
        {
            var departments = _departmentEF.GetAll();
            return View(departments);
        }

        // GET: DepartmentsEFController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentsEFController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentsEFController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            try
            {
                //check validation
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var result = _departmentEF.Add(department);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentsEFController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentsEFController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentsEFController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentsEFController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
