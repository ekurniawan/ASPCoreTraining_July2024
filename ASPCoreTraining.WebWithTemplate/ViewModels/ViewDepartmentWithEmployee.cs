using ASPCoreTraining.Domain;

namespace ASPCoreTraining.WebWithTemplate.ViewModels
{
    public class ViewDepartmentWithEmployee
    {
        public Department Department { get; set; } = null!;
        public IEnumerable<Employee> Employees { get; set; } = null!;
    }
}
