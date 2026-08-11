using AutoMapper;
using HospitalManagementAPI.DTOs;
using HospitalManagementAPI.Models;
using HospitalManagementAPI.Repositories.Interfaces;
using HospitalManagementAPI.Services.Interfaces;
using HospitalManagementAPI.Exceptions;

namespace HospitalManagementAPI.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<PatientService> _logger;

        public PatientService(
    IPatientRepository repository,
    IMapper mapper,
    ILogger<PatientService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<PatientResponseDto>> GetAllAsync()
        {
            var patients = await _repository.GetAllAsync();

            return _mapper.Map<List<PatientResponseDto>>(patients);
        }

        //public async Task<PatientResponseDto?> GetByIdAsync(int id)
        //{
        //    var patient = await _repository.GetByIdAsync(id);

        //    if (patient == null)
        //    {
        //        return null;
        //    }

        //    return _mapper.Map<PatientResponseDto>(patient);
        //}

        public async Task<PatientResponseDto> GetByIdAsync(int id)
        {
            _logger.LogInformation(
                "Getting patient with ID {PatientId}",
                id);

            var patient = await _repository.GetByIdAsync(id);

            if (patient == null)
            {
                _logger.LogWarning(
                    "Patient with ID {PatientId} was not found",
                    id);

                throw new NotFoundException(
                    $"Patient with ID {id} was not found.");
            }

            _logger.LogInformation(
                "Patient with ID {PatientId} retrieved successfully",
                id);

            return _mapper.Map<PatientResponseDto>(patient);
        }

        public async Task<PatientResponseDto> CreateAsync(
            CreatePatientDto dto)
        {
            var patient = _mapper.Map<Patient>(dto);

            var createdPatient =
                await _repository.CreateAsync(patient);

            return _mapper.Map<PatientResponseDto>(
                createdPatient);
        }


        public async Task<bool> UpdateAsync(
            int id,
            UpdatePatientDto dto)
        {
            var patient = await _repository.GetByIdAsync(id);

            if (patient == null)
            {
                return false;
            }

            _mapper.Map(dto, patient);

            await _repository.UpdateAsync(patient);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var patient = await _repository.GetByIdAsync(id);

            if (patient == null)
            {
                throw new NotFoundException(
                    $"Patient with ID {id} was not found.");
            }

            await _repository.DeleteAsync(id);

            return true;
        }
    }
}