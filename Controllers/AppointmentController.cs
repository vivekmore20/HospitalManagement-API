using AutoMapper;
using HospitalApp.DTO;
using HospitalApp.Models;
using HospitalApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Controllers
{
    [ApiController]
    
    [Route("api/[controller]/[action]")]
    public class AppointmentController : Controller
    {
     
        private readonly IAppointmentRepo _appointmentRepo;
        public AppointmentController( IAppointmentRepo appointmentRepo)
        {
            
            _appointmentRepo = appointmentRepo;
            
        }

        [HttpPost]
        public IActionResult AddAppointment([FromBody] AppointmentDto appointment)
        {
            int res = _appointmentRepo.AddAppointment(appointment);
            if (res == 1)
            {
                return Ok(appointment);
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetAllAppointments()
        {
            var app = _appointmentRepo.GetAllAppointments();
            return Ok(app);
        }

    }
}
