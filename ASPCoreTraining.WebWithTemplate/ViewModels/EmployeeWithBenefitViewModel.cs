using ASPCoreTraining.DomainEF;

namespace ASPCoreTraining.WebWithTemplate.ViewModels
{
    public class EmployeeWithBenefitViewModel
    {
        public Employee Employee { get; set; } = null!;
        public IEnumerable<Benefit> EmpBenefits { get; set; } = null!;
        public IEnumerable<Department> Departments { get; set; } = null!;
    }
}
