using AutoMapper;
using HospitalManagementAPI.DTOs;
using HospitalManagementAPI.Models;
using HospitalManagementAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HospitalManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepository _repository;
        private readonly IMapper _mapper;

        public DoctorsController(
            IDoctorRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _repository.GetAllAsync();

            var response =
                _mapper.Map<List<DoctorResponseDto>>(doctors);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var doctor = await _repository.GetByIdAsync(id);

            if (doctor == null)
            {
                return NotFound("Doctor not found");
            }

            var response =
                _mapper.Map<DoctorResponseDto>(doctor);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(
            CreateDoctorDto dto)
        {
            var doctor = _mapper.Map<Doctor>(dto);

            var createdDoctor =
                await _repository.CreateAsync(doctor);

            var response =
                _mapper.Map<DoctorResponseDto>(createdDoctor);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(
            int id,
            UpdateDoctorDto dto)
        {
            var existingDoctor =
                await _repository.GetByIdAsync(id);

            if (existingDoctor == null)
            {
                return NotFound("Doctor not found");
            }

            _mapper.Map(dto, existingDoctor);

            await _repository.UpdateAsync(existingDoctor);

            var response =
                _mapper.Map<DoctorResponseDto>(existingDoctor);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor =
                await _repository.GetByIdAsync(id);

            if (doctor == null)
            {
                return NotFound("Doctor not found");
            }

            await _repository.DeleteAsync(id);

            return Ok("Doctor deleted successfully");
        }

    }
}