using FinalProject.Data.Models;

namespace FinalProject.Service.Interfaces;

public interface IPatientService
{
    Task<Patient> GetPatientByIdWithoutIncludeAsync(int id);
    Task<Patient> GetPatientByIdWithIncludeAsync(int id);
    Task AddPatientAsync(Patient patient);
    
    Task UpdatePatientAsync(Patient patient);
    
    Task SaveChangesAsync();
    
}