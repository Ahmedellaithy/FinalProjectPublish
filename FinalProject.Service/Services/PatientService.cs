using FinalProject.Data.Models;
using FinalProject.Infrastructure.Interfaces;
using FinalProject.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Service.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patient;
    public PatientService(IPatientRepository patient)
    {
        _patient = patient;
    }


    public async Task<Patient> GetPatientByIdWithoutIncludeAsync(int id)
    {
        var patient = await _patient.GetPatientByIdAsync(id);
        return patient;
    }

    public async Task<Patient> GetPatientByIdWithIncludeAsync(int id)
    {
        var patient = await _patient.GetTableNoTracking().Include(x => x.ApplicationUser)
            .Where(x => x.Id == id).SingleOrDefaultAsync();
        
        return patient;
    }

    
    public async Task AddPatientAsync(Patient patient)
    {
        await _patient.AddAsync(patient);
        await _patient.SaveChangesAsync();
    }

    public async Task UpdatePatientAsync(Patient patient)
    {
        await _patient.UpdateAsync(patient);
        await _patient.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _patient.SaveChangesAsync();
    }
    
}