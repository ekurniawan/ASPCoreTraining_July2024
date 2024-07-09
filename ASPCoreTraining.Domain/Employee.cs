using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPCoreTraining.Domain
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        public string EmployeeIdMasking { get; set; } = null!;

        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Department { get; set; } = null!;
    }
}
