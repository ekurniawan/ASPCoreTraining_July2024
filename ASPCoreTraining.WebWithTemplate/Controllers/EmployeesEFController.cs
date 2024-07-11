using ASPCoreTraining.DataEF.Interfaces;
using ASPCoreTraining.WebWithTemplate.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreTraining.WebWithTemplate.Controllers
{
    public class EmployeesEFController : Controller
    {
        private readonly IEmployeeEF _employeeEF;
        private readonly IDepartmentEF _departmentEF;

        public EmployeesEFController(IEmployeeEF employeeEF, IDepartmentEF departmentEF)
        {
            _employeeEF = employeeEF;
            _departmentEF = departmentEF;
        }

        // GET: EmployeesEFController
        public ActionResult Index()
        {
            var models = _employeeEF.GetAll();
            return View(models);
        }

        // GET: EmployeesEFController/Details/5
        public ActionResult Details(string id)
        {
            var employeebenefit = _employeeEF.GetEmployeeWithBenefit(id);
            var departments = _departmentEF.GetAll();
            var models = new EmployeeWithBenefitViewModel
            {
                Employee = employeebenefit.FirstOrDefault().Employee,
                EmpBenefits = employeebenefit.Select(e => e.Benefit),
                Departments = departments
            };
            return View(models);
        }

        // GET: EmployeesEFController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesEFController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: EmployeesEFController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesEFController/Edit/5
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

        // GET: EmployeesEFController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesEFController/Delete/5
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
