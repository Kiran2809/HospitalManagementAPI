using HospitalManagementAPI.DTOs;
using HospitalManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _service.GetAllAsync();

            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _service.GetByIdAsync(id);

            if (patient == null)
            {
                return NotFound("Patient not found");
            }

            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient(
            CreatePatientDto dto)
        {
            var patient = await _service.CreateAsync(dto);

            return Ok(patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(
            int id,
            UpdatePatientDto dto)
        {
            var result =
                await _service.UpdateAsync(id, dto);

            if (!result)
            {
                return NotFound("Patient not found");
            }

            return Ok("Patient updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
            {
                return NotFound("Patient not found");
            }

            return Ok("Patient deleted successfully");
        }
    }
}