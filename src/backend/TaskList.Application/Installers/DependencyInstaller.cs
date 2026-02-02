using Microsoft.Extensions.DependencyInjection;
using TaskList.Application.Services.Impl;
using TaskList.Domain.Services.Interfaces;

namespace TaskList.Application.Installers;

public static class DependencyInstaller
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ITaskServices, TaskServices>();

        return services;
    }    
}
