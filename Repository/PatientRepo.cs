using AutoMapper;
using HospitalApp.DTO;
using HospitalApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repository
{
    public class PatientRepo : IPatientRepo
    {
        private readonly HospitalDbContext _context;
        private readonly IMapper _mapper;
        public PatientRepo(HospitalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int AddPatient(PatientDto p)
        {
            try
            {
                var obj = _mapper.Map<Patient>(p);
                if (obj != null)
                {
                    _context.Patients.Add(obj);
                    _context.SaveChanges();
                    return 1;
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());

            }
            return 0;
        }

        public async Task<int> DeletePatient(int patientId)
        {
            try
            {
                int affectedRows = await _context.Database.ExecuteSqlRawAsync("DeletePatientById @patientId", new SqlParameter("@patientId", patientId));

                return affectedRows;

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());

            }
            return 0;
        }

        public async Task<ResponseDto<List<Patient>>> GetAllPatients()
        {
            try
            {
                var patientsList = await _context.Patients.FromSqlRaw("GetAllPatients").ToListAsync();

                var responseDto = new ResponseDto<List<Patient>>
                {
                    Success = true,
                    Message = "Success",
                    Data = patientsList
                };

                return responseDto;
            }
            catch (Exception ex)
            {

                var errorResponse = new ResponseDto<List<Patient>>
                {
                    Success = false,
                    Message = "An error occurred while fetching patients.",
                    Data = null
                };

                return errorResponse;
            }
        }

        public int UpdatePatient(int patientId, Patient p)
        {
            try
            {
                var obj = _context.Patients.FirstOrDefault(p => p.PatientId == patientId);
                if (obj != null)
                {
                    obj.Address = p.Address;
                    obj.PatientId = patientId;
                    obj.ContactNumber = p.ContactNumber;
                    obj.LastName = p.LastName;
                    obj.FirstName = p.FirstName;
                    _context.Update(obj);
                    _context.SaveChanges();
                    return 1;
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            return 0;
        }

        public List<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            try
            {
                List<Appointment> li = new List<Appointment>();

                li.AddRange(_context.Appointments.Where(a => a.PatientId == patientId).ToList());
                return li;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());

            }
            return new List<Appointment>();
        }
    }
}
