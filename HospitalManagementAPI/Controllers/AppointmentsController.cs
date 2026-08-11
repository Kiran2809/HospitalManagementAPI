using HospitalManagementAPI.DTOs;
using HospitalManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(
            IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var appointments =
                await _service.GetAllAsync();

            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            var appointment =
                await _service.GetByIdAsync(id);

            if (appointment == null)
            {
                return NotFound("Appointment not found");
            }

            return Ok(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(
            CreateAppointmentDto dto)
        {
            var result =
                await _service.CreateAsync(dto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(
            int id,
            UpdateAppointmentDto dto)
        {
            var result =
                await _service.UpdateAsync(id, dto);

            if (!result)
            {
                return NotFound("Appointment not found");
            }

            return Ok("Appointment updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var result =
                await _service.DeleteAsync(id);

            if (!result)
            {
                return NotFound("Appointment not found");
            }

            return Ok("Appointment deleted successfully");
        }
    }
}