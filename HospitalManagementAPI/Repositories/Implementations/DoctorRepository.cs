using HospitalManagementAPI.Data;
using HospitalManagementAPI.Models;
using HospitalManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementAPI.Repositories.Implementations
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
            return await _context.Doctors
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Doctor> CreateAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);

            await _context.SaveChangesAsync();

            return doctor;
        }

        //public async Task UpdateAsync(Doctor doctor)
        //{
        //    _context.Doctors.Update(doctor);

        //    await _context.SaveChangesAsync();
        //}

        public async Task UpdateAsync(Doctor doctor)
        {
            var existingDoctor = await _context.Doctors
                .FirstOrDefaultAsync(d => d.Id == doctor.Id);

            if (existingDoctor == null)
            {
                return;
            }

            existingDoctor.Name = doctor.Name;
            existingDoctor.Specialization = doctor.Specialization;
            existingDoctor.Email = doctor.Email;
            existingDoctor.Phone = doctor.Phone;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var doctor = await GetByIdAsync(id);

            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);

                await _context.SaveChangesAsync();
            }
        }
    }
}