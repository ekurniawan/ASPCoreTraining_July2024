﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ASPCoreTraining.DomainEF;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}