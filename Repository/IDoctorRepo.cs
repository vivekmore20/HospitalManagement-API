using HospitalApp.DTO;
using HospitalApp.Models;

namespace HospitalApp.Repository
{
    public interface IDoctorRepo
    {
        public int AddDoctor(DoctorDto doctor);

        public int UpdateDoctor(int doctorId, DoctorDto doctor);

        public int DeleteDoctor(int doctorId);

        public List<Doctor> GetAllDoctors();

        List<Appointment> GetAllAppointmentsByDoctorId(int doctorId);
    }
}
