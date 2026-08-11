using HospitalManagementAPI.Models;

namespace HospitalManagementAPI.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAllAsync();

        Task<Appointment?> GetByIdAsync(int id);

        Task<Appointment> CreateAsync(Appointment appointment);

        Task UpdateAsync(Appointment appointment);

        Task DeleteAsync(int id);

        Task<bool> IsDoctorAvailableAsync(
            int doctorId,
            DateTime appointmentDate);
    }
}