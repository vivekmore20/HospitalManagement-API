using AutoMapper;
using HospitalApp.DTO;
using HospitalApp.Models;

namespace HospitalApp.Repository
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly HospitalDbContext _context;
        private readonly IMapper _mapper;

        public AppointmentRepo(HospitalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public int AddAppointment(AppointmentDto appointmentDto)
        {
            var obj = _mapper.Map<Appointment>(appointmentDto);

            if (obj != null)
            {

                _context.Appointments.Add(obj);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }


        public List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointmentsList = new List<Appointment>();
            foreach (var A in _context.Appointments)
            {
                appointmentsList.Add(_mapper.Map<Appointment>(A));
            }
            return appointmentsList;
        }

    }
}
