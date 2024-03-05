using HospitalApp.DTO;
using HospitalApp.Models;
using HospitalManagement.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PatientController : Controller
    {
        private HospitalDbContext _context;
        private IPatientRepo _patientRepo;
        private readonly ILogger<PatientController> _logger;

        
        public PatientController(HospitalDbContext context, IPatientRepo patientRepo, ILogger<PatientController> logger)
        {
            _context = context;
            _patientRepo = patientRepo;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddPatient([FromBody] PatientDto p)
        {
            _logger.LogInformation(" I'm from patient logger INFO");
            _logger.LogDebug(" I'm from patient logger Debug");
            _logger.LogError(" I'm from patient logger Error");
            _logger.LogCritical(" I'm from patient logger critical");


            int res = _patientRepo.AddPatient(p);
            if (res == 1)
            {
                return Ok(p);
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<String>> DeletePatient(int id)
        {
            int res = await _patientRepo.DeletePatient(id);
            if (res == 1)
            {
                return Ok("Patient Deleted Sucessfully");
            }
            return BadRequest();
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdatePatient(int id, Patient p)
        {

            int res = _patientRepo.UpdatePatient(id, p);
            if (res == 1)
            {
                return Ok("Patient Details Updated Sucessfully");
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<Patient>>>> GetAllPatients()
        {

            var response = await _patientRepo.GetAllPatients();
            var t = response.Data;
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }

        }

        [HttpGet("{id:int}")]
        public IActionResult GetAppointmentByPatientId(int id) {

            List<Appointment> list = _patientRepo.GetAppointmentsByPatientId(id);
            if (list.Count == 0)
            {
                return Ok("No Record Found");
            }
            return Ok(list);


        }



    }
}
