using ASPCoreTraining.Data.Interfaces;
using ASPCoreTraining.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreTraining.WebWithTemplate.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeDAL _employeeDAL;
        public EmployeesController(IEmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }

        // GET: EmployeesController
        public ActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            var results = _employeeDAL.GetAll();
            return View(results);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(string id)
        {
            var result = _employeeDAL.GetById(id);
            return View(result);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeIdMasking = Guid.NewGuid().ToString();
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                //check model validation
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var result = _employeeDAL.Add(employee);
                TempData["Message"] = "<span class='text-success'>Employee added successfully</span>";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(string id)
        {
            var editEmployee = _employeeDAL.GetById(id);
            return View(editEmployee);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Employee employee)
        {
            try
            {
                //check model validation
                if (!ModelState.IsValid)
                {
                    return View("Edit");
                }

                var result = _employeeDAL.Update(employee);

                TempData["Message"] = "<span class='text-success'>Employee updated successfully</span>";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Edit");
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
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
