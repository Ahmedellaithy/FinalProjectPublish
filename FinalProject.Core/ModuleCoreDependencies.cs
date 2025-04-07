using System.Reflection;
using FinalProject.Data.Identity;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Core;

public static class ModuleCoreDependencies
{
    public static IServiceCollection AddCore(this IServiceCollection service)
    {
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        service.AddAutoMapper(Assembly.GetExecutingAssembly());
        service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return service;
    }
}