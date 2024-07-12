using ASPCoreTraining.DataEF.Interfaces;
using ASPCoreTraining.DomainEF;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPCoreTraining.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentEF _departmentEF;
        public DepartmentsController(IDepartmentEF departmentEF)
        {
            _departmentEF = departmentEF;
        }

        // GET: api/<DepartmentsController>
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            var departments = _departmentEF.GetAll();
            return departments;
        }



        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public Department Get(string id)
        {
            var department = _departmentEF.GetById(id);
            return department;
        }

        [HttpGet("ByName")]
        public IEnumerable<Department> GetByName(string name)
        {
            var departments = _departmentEF.GetByName(name);
            return departments;
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public ActionResult Post([FromBody] Department department)
        {
            try
            {
                var result = _departmentEF.Add(department);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Department department)
        {
            try
            {
                var updateDepartment = _departmentEF.GetById(id);
                updateDepartment.DepartmentName = department.DepartmentName;
                var result = _departmentEF.Update(updateDepartment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                _departmentEF.Delete(id);
                return Ok("Data berhasil didelete !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
