using AutoMapper;
using HospitalApp.DTO;
using HospitalApp.Models;

namespace HospitalApp.Repository
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly HospitalDbContext _context;
        private readonly IMapper _mapper;

        public DoctorRepo(HospitalDbContext hospitalDbContext, IMapper mapper)
        {
            _context = hospitalDbContext;
            _mapper = mapper;

        }

        public int AddDoctor(DoctorDto doctorDto)
        {
            var obj = _mapper.Map<Doctor>(doctorDto);
            if (obj != null)
            {
                _context.Doctors.Add(obj);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int DeleteDoctor(int doctorId)
        {
            var obj = _context.Doctors.FirstOrDefault(d => d.DoctorId == doctorId);
            if (obj != null)
            {
                _context.Doctors.Remove(obj);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctorList = new List<Doctor>();
            foreach (Doctor d in _context.Doctors)
            {
                doctorList.Add(_mapper.Map<Doctor>(d));
            }
            return doctorList;

        }
        public int UpdateDoctor(int doctorId, DoctorDto d)
        {
            var obj = _context.Doctors.FirstOrDefault(d => d.DoctorId == doctorId);
            if (obj != null)
            {
                var obj1 = _mapper.Map<DoctorDto>(obj);
                obj.DoctorId = doctorId;
                _context.Doctors.Update(obj);
                return 1;
            }
            return 0;
        }

        public List<Appointment> GetAllAppointmentsByDoctorId(int doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();

            appointments.AddRange(_context.Appointments.Where(a => a.DoctorId == doctorId).ToList());
            return appointments;


        }
    }
}
