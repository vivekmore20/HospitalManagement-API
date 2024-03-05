using System;
using System.Collections.Generic;

namespace HospitalApp.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Specialization { get; set; }

    public string? ContactNumber { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();

    public virtual ICollection<Department> Departments { get; } = new List<Department>();
}
