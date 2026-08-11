using HospitalManagementAPI.DTOs;

namespace HospitalManagementAPI.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<List<AppointmentResponseDto>> GetAllAsync();

        Task<AppointmentResponseDto?> GetByIdAsync(int id);

        Task<(bool Success, string Message,
            AppointmentResponseDto? Data)> CreateAsync(
                CreateAppointmentDto dto);

        Task<bool> UpdateAsync(
            int id,
            UpdateAppointmentDto dto);

        Task<bool> DeleteAsync(int id);
    }
}