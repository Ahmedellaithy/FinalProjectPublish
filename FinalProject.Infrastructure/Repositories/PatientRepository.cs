using FinalProject.Data.Models;
using FinalProject.Infrastructure.Context;
using FinalProject.Infrastructure.GenericRepositories;
using FinalProject.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Repositories;

public class PatientRepository : GenericRepository<Patient>,
                                 IPatientRepository

{
    private readonly DbSet<Patient> _patient;
    public PatientRepository(ApplicationDbContext context) : base(context)
    {
        _patient = context.Set<Patient>();
    }

    public async Task<ICollection<Patient>> GetAllPatientsAsync()
    {
        ICollection<Patient> patients = await _patient.ToListAsync();
        return patients;
    }

    public async Task<Patient> GetPatientByIdAsync(int id)
    {
        var patient = await _patient.FindAsync(id);
        return patient;
    }
    
}