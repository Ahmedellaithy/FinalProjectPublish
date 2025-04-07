using FinalProject.Infrastructure.GenericRepositories;
using FinalProject.Infrastructure.Interfaces;
using FinalProject.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Infrastructure;

public static class ModuleInfrastrucutureDependencies
{
    public static IServiceCollection AddInfrastrucutre(this IServiceCollection service)
    {
        service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        service.AddTransient<IDoctorRepository, DoctorRepository>();
        service.AddTransient<IReservationRepository, ReservationRepository>();
        service.AddTransient<IPatientRepository, PatientRepository>();
        service.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
        return service;
    } 
}