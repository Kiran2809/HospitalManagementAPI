using HospitalManagementAPI.DTOs;

namespace HospitalManagementAPI.Services.Interfaces
{
    public interface IPatientService
    {
        Task<List<PatientResponseDto>> GetAllAsync();

        Task<PatientResponseDto?> GetByIdAsync(int id);

        Task<PatientResponseDto> CreateAsync(
            CreatePatientDto dto);

        Task<bool> UpdateAsync(
            int id,
            UpdatePatientDto dto);

        Task<bool> DeleteAsync(int id);
    }
}