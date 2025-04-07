using FinalProject.Data.Models;
using FinalProject.Infrastructure.GenericRepositories;

namespace FinalProject.Infrastructure.Interfaces;

public interface IDoctorRepository : IGenericRepository<Doctor>
{
    Task<ICollection<Doctor>> GetAllDoctorsAsync();
    Task<Doctor> GetDoctorByIdAsync(int id);
    void RemoveDoctorAsync(Doctor doctor);
}