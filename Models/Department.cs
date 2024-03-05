using System;
using System.Collections.Generic;

namespace HospitalApp.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public int? HeadDoctorId { get; set; }

    public virtual Doctor? HeadDoctor { get; set; }
}
