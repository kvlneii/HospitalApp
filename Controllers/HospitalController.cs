using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HospitalApp.Models.DTO;
using HospitalApp.Services;

namespace HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalDbService _hospitalDbService;

        public HospitalController(IHospitalDbService hospitalDbService)
        {
            _hospitalDbService = hospitalDbService;
        }

        [HttpGet("doctors")]
        public async Task<IActionResult> GetDoctors()
        {
            var result = await _hospitalDbService.GetDoctorsAsync();

            if (result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpPost("doctors")]
        public async Task<IActionResult> AddDoctor(DoctorDTO dto)
        {
            var result = await _hospitalDbService.AddDoctorAsync(dto);

            if (result != "Success!")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("doctors/{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var result = await _hospitalDbService.DeleteDoctorAsync(id);

            if (result != "Success!")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("doctors/{doctorId}")]
        public async Task<IActionResult> ChangeDoctor(int doctorId, DoctorDTO dto)
        {
            var result = await _hospitalDbService.ChangeDoctorAsync(doctorId, dto);

            if (result != "Success!")
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("prescriptions/{idPrescription}")]
        public async Task<IActionResult> GetPrescription(int idPrescription)
        {
            var result = await _hospitalDbService.GetPrescriptionAsync(idPrescription);

            if (result == null)
                return NotFound($"There is no such prescription with id => {idPrescription} in DB");

            return Ok(result);
        }
    }
}
