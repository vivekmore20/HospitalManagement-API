using System;
using System.Collections.Generic;

namespace HospitalApp.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? Dob { get; set; }

    public string? Gender { get; set; }

    public string? ContactNumber { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();
}
