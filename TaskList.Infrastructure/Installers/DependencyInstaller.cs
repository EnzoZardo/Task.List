
using Microsoft.Extensions.DependencyInjection;
using TaskList.Domain.Persistence.Interfaces;
using TaskList.Infrastructure.Persistence.Impl;

namespace TaskList.Infrastructure.Installers;

public static class DependencyInstaller
{
    public static IServiceCollection AddInfrastrucure(this IServiceCollection services)
    {
        services.AddScoped<ITaskRepository, TaskRepository>();

        return services;
    }    
}
