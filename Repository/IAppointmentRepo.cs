using HospitalApp.DTO;
using HospitalApp.Models;

namespace HospitalApp.Repository
{
    public interface IAppointmentRepo
    {
        int AddAppointment(AppointmentDto appointmentDto);

        List<Appointment> GetAllAppointments();

        
    }
}
