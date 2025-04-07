using FinalProject.Data.Models;
using FinalProject.Infrastructure.Context;
using FinalProject.Infrastructure.GenericRepositories;
using FinalProject.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Repositories;

public class DoctorRepository : GenericRepository<Doctor>,
                                IDoctorRepository
{
    private readonly DbSet<Doctor> _doctors;
    public DoctorRepository(ApplicationDbContext context) : base(context)
    {
        _doctors = context.Set<Doctor>();
    }

    public async Task<ICollection<Doctor>> GetAllDoctorsAsync()
    {
        var doctors = await _doctors.ToListAsync();
        return doctors;
    }

    public async Task<Doctor> GetDoctorByIdAsync(int id)
    {
        var doctor = await _doctors.AsNoTracking()
            .Include(x => x.ApplicationUser)
            .Where(x => x.Id == id).FirstOrDefaultAsync();
        
        return doctor;
    }

    public void RemoveDoctorAsync(Doctor doctor)
    {
        _doctors.Remove(doctor);
    }
}