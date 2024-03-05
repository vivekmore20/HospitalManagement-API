using AutoMapper;
using HospitalApp.DTO;
using HospitalApp.Models;


namespace HospitalManagement.Helper
{
    public class ApplicationModelMapping:Profile
    {
        public ApplicationModelMapping() {
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDto>().ReverseMap();  


        }
    }
}
