using HospitalManagementAPI.Models;

namespace HospitalManagementAPI.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllAsync();

        Task<Patient?> GetByIdAsync(int id);

        Task<Patient> CreateAsync(Patient patient);

        Task UpdateAsync(Patient patient);

        Task DeleteAsync(int id);
    }
}