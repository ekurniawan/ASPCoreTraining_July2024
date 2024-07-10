using ASPCoreTraining.Data.Interfaces;
using ASPCoreTraining.WebWithTemplate.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreTraining.WebWithTemplate.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentDAL _departmentDAL;
        private readonly IEmployeeDAL _employeeDAL;

        public DepartmentsController(IDepartmentDAL departmentDAL, IEmployeeDAL employeeDAL)
        {
            _departmentDAL = departmentDAL;
            _employeeDAL = employeeDAL;
        }
        // GET: DepartmentsController
        public ActionResult Index()
        {
            var results = _departmentDAL.GetAll();
            return View(results);
        }

        // GET: DepartmentsController/Details/5
        public ActionResult Details(string id)
        {
            var department = _departmentDAL.GetById(id);
            var employees = _employeeDAL.GetByDepartmentId(department.DepartmentId);
            var viewDepartmentWithEmployee = new ViewDepartmentWithEmployee
            {
                Department = department,
                Employees = employees
            };
            return View(viewDepartmentWithEmployee);
        }

        // GET: DepartmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentsController/Create
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

        // GET: DepartmentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentsController/Edit/5
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

        // GET: DepartmentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentsController/Delete/5
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
