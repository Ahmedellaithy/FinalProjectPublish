using FinalProject.Service.Interfaces;
using FinalProject.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Service;

public static class ModuleServiceDependencies
{
    public static IServiceCollection AddService(this IServiceCollection service)
    {
        service.AddTransient<IAuthenticationService, AuthenticationService>();
        service.AddTransient<IDoctorService,DoctorService>();
        service.AddTransient<IReservationService, ReservationService>();
        service.AddTransient<IPatientService, PatientService>();
        service.AddTransient<IPayPalService, PayPalService>();
        return service;
    }
}