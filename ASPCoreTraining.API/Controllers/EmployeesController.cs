using ASPCoreTraining.API.DTOs;
using ASPCoreTraining.DataEF;
using ASPCoreTraining.DataEF.Interfaces;
using ASPCoreTraining.DomainEF;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPCoreTraining.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeEF _employeeEF;
        public EmployeesController(IEmployeeEF employeeEF)
        {
            _employeeEF = employeeEF;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<EmployeeDTO> Get()
        {
            List<EmployeeDTO> employeeDtos = new List<EmployeeDTO>();
            var employees = _employeeEF.GetAll();
            foreach (var employee in employees)
            {
                employeeDtos.Add(new EmployeeDTO
                {
                    EmployeeId = employee.EmployeeId,
                    FullName = employee.FullName,
                    Email = employee.Email,
                    Department = new DepartmentDTO
                    {
                        DepartmentId = employee.Department.DepartmentId,
                        DepartmentName = employee.Department.DepartmentName
                    }
                });
            }
            return employeeDtos;
        }

        [HttpGet("GetBenefits/{id}")]
        public IEnumerable<BenefitEmployee> GetBenefits(string id)
        {
            var benefits = _employeeEF.GetEmployeeWithBenefit(id);
            return benefits;
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
