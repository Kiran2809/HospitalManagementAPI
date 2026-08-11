using AutoMapper;
using HospitalManagementAPI.DTOs;
using HospitalManagementAPI.Models;
using HospitalManagementAPI.Repositories.Interfaces;
using HospitalManagementAPI.Services.Interfaces;
using HospitalManagementAPI.Exceptions;

namespace HospitalManagementAPI.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public AppointmentService(
            IAppointmentRepository appointmentRepository,
            IPatientRepository patientRepository,
            IDoctorRepository doctorRepository,
            IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<List<AppointmentResponseDto>> GetAllAsync()
        {
            var appointments =
                await _appointmentRepository.GetAllAsync();

            return _mapper.Map<List<AppointmentResponseDto>>(
                appointments);
        }

        public async Task<AppointmentResponseDto?> GetByIdAsync(int id)
        {
            var appointment =
                await _appointmentRepository.GetByIdAsync(id);

            if (appointment == null)
            {
                return null;
            }

            return _mapper.Map<AppointmentResponseDto>(
                appointment);
        }

        public async Task<(bool Success, string Message,
            AppointmentResponseDto? Data)> CreateAsync(
                CreateAppointmentDto dto)
        {
            // 1. Check patient
            var patient =
                await _patientRepository.GetByIdAsync(dto.PatientId);

            //if (patient == null)
            //{
            //    return (false, "Patient not found", null);
            //}
            if (patient == null)
            {
                throw new NotFoundException(
                    $"Patient with ID {dto.PatientId} was not found.");
            }


            // 2. Check doctor
            var doctor =
                await _doctorRepository.GetByIdAsync(dto.DoctorId);

            //if (doctor == null)
            //{
            //    return (false, "Doctor not found", null);
            //}
            if (doctor == null)
            {
                throw new NotFoundException(
                    $"Doctor with ID {dto.DoctorId} was not found.");
            }


            // 3. Check doctor availability
            var available =
                await _appointmentRepository
                    .IsDoctorAvailableAsync(
                        dto.DoctorId,
                        dto.AppointmentDate);

            if (!available)
            {
                return (
                    false,
                    "Doctor is already booked for this time",
                    null);
            }

            // 4. Map DTO to Entity
            var appointment =
                _mapper.Map<Appointment>(dto);

            appointment.Status = "Pending";

            // 5. Save
            var created =
                await _appointmentRepository
                    .CreateAsync(appointment);

            // 6. Get complete appointment
            var result =
                await _appointmentRepository
                    .GetByIdAsync(created.Id);

            var response =
                _mapper.Map<AppointmentResponseDto>(
                    result);

            return (
                true,
                "Appointment created successfully",
                response);
        }

        public async Task<bool> UpdateAsync(
            int id,
            UpdateAppointmentDto dto)
        {
            var appointment =
                await _appointmentRepository.GetByIdAsync(id);

            if (appointment == null)
            {
                return false;
            }

            _mapper.Map(dto, appointment);

            await _appointmentRepository
                .UpdateAsync(appointment);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var appointment =
                await _appointmentRepository.GetByIdAsync(id);

            if (appointment == null)
            {
                return false;
            }

            await _appointmentRepository.DeleteAsync(id);

            return true;
        }
    }
}