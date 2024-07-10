﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPCoreTraining.Domain
{
    public class ViewEmployeeWithDepartment
    {
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int EmployeeId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
    }
}
