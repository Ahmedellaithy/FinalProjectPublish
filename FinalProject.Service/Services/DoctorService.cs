using System.Collections;
using FinalProject.Data.DoctorResponse;
using FinalProject.Data.Identity;
using FinalProject.Data.Models;
using FinalProject.Infrastructure.Interfaces;
using FinalProject.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Service.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly UserManager<ApplicationUser> _user;
    public DoctorService(IDoctorRepository doctorRepository, UserManager<ApplicationUser> user)
    {
        _doctorRepository = doctorRepository;
        _user = user;
    }

    public async Task<ICollection<Doctor>> GetAllDoctorsAsync()
    {
        ICollection<Doctor> doctors = await _doctorRepository.GetAllDoctorsAsync();
        return doctors;
    }

    public async Task<Doctor> GetDoctorByIdAsync(int id)
    {
        var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
        return doctor;
    }

    
    public async Task<Doctor> GetDoctorByIdWithIncludesAsync(int id)
    {
        var doctor = await _doctorRepository.GetTableNoTracking()
            .Include(x => x.ApplicationUser)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        return doctor;
    }
    
    
    public async Task<Doctor> GetLastDoctorAsync()
    {
        var doctors = await _doctorRepository.GetAllDoctorsAsync();
        return doctors.LastOrDefault();
    }

    public async Task<string> AddDoctorAsync(Doctor doctr)
    {
        await _doctorRepository.AddAsync(doctr);
        _doctorRepository.SaveChangesAsync();
        return "Added Successfully";
    }

    public IQueryable<Doctor> GetDoctorsQuerable()
    {
        return _doctorRepository.GetTableNoTracking()
            .Include(x=>x.ApplicationUser)
            .AsQueryable();
    }

    public async Task RemoveDoctorAsync(Doctor doctor)
    {
        await _user.DeleteAsync(doctor.ApplicationUser);
    }

    public async Task SaveChangesAsync()
    {
        await _doctorRepository.SaveChangesAsync();
    }
    
    
    public async Task UpdateDoctorAsync(Doctor doctr)
    {
        await _doctorRepository.UpdateAsync(doctr);
        await _doctorRepository.SaveChangesAsync();
    }
    
}