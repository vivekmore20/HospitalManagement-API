using HospitalApp.DTO;

using HospitalApp.Models;
using HospitalApp.Repository;
using Microsoft.AspNetCore.Mvc;


namespace HospitalApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DoctorController : Controller
    {
        private HospitalDbContext _context;
        private IDoctorRepo _doctorRepo;
        public DoctorController(HospitalDbContext context, IDoctorRepo doctorRepo)
        {
            _context = context;
            _doctorRepo = doctorRepo;
        }

        [HttpPost]
        public IActionResult AddDoctor([FromBody] DoctorDto d)
        {
            int res = _doctorRepo.AddDoctor(d);
            if (res == 1)
            {
                return Ok(d);
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteDoctor(int id)
        {
            int res = _doctorRepo.DeleteDoctor(id);
            if (res == 1)
            {
                return Ok("Doctor Deleted Sucessfully");
            }
            return BadRequest();
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateDoctor(int id, [FromBody] DoctorDto d)
        {

            int res = _doctorRepo.UpdateDoctor(id, d);
            if (res == 1)
            {
                return Ok("Patient Details Updated Sucessfully");
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetAllDoctors()
        {

            return Ok(_doctorRepo.GetAllDoctors());

        }

        [HttpGet("{id:int}")]
        public IActionResult GetAllAppointmentsByDoctorId(int id) {
            List<Appointment> list = _doctorRepo.GetAllAppointmentsByDoctorId(id);
            if(list.Count == 0)
            {
                return Ok("No Record Found");
            }
            return Ok(list);
        }

    }
}
