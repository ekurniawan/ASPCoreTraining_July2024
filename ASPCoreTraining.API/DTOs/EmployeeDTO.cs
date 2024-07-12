using ASPCoreTraining.DomainEF;

namespace ASPCoreTraining.API.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public DepartmentDTO? Department { get; set; }
    }
}
