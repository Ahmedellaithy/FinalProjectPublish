using FinalProject.Data.Models;
using FinalProject.Infrastructure.GenericRepositories;

namespace FinalProject.Infrastructure.Interfaces;

public interface IPatientRepository : IGenericRepository<Patient>
{
    Task<ICollection<Patient>> GetAllPatientsAsync();
    Task<Patient> GetPatientByIdAsync(int id);
}