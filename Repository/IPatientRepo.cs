using HospitalApp.DTO;
using HospitalApp.Models;

namespace HospitalManagement.Repository
{
    public interface IPatientRepo
    {
         int AddPatient(PatientDto p);

         int UpdatePatient(int patientId,Patient p);

        Task<int> DeletePatient(int patientId);

       //  List<Patient>GetAllPatients();

        List<Appointment> GetAppointmentsByPatientId(int patientId);

        public  Task<ResponseDto<List<Patient>>> GetAllPatients();
    
    }
}
