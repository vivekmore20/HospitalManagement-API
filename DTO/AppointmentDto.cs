﻿using HospitalApp.Models;

namespace HospitalApp.DTO
{
    public class AppointmentDto
    {
    
        public int? PatientId { get; set; }

        public int? DoctorId { get; set; }

        public DateTime? AppointmentDate { get; set; }

        public string? Status { get; set; }

        public string? Notes { get; set; }

    }
}
