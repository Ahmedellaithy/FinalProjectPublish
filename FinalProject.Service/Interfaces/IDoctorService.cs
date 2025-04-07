using FinalProject.Data.Models;

namespace FinalProject.Service.Interfaces;

public interface IDoctorService
{
    Task UpdateDoctorAsync(Doctor doctor);
    Task<ICollection<Doctor>> GetAllDoctorsAsync();
    Task RemoveDoctorAsync(Doctor doctor);      
    Task<Doctor> GetDoctorByIdAsync(int id);
    Task<Doctor> GetDoctorByIdWithIncludesAsync(int id);
    Task<Doctor> GetLastDoctorAsync();
    Task<string> AddDoctorAsync(Doctor doctor);

    IQueryable<Doctor> GetDoctorsQuerable();
    
    Task SaveChangesAsync();

}