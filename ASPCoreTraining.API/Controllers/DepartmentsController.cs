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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
