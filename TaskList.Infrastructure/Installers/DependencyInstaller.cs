
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskList.Domain.Persistence.Interfaces;
using TaskList.Infrastructure.Context;
using TaskList.Infrastructure.Persistence.Impl;

namespace TaskList.Infrastructure.Installers;

public static class DependencyInstaller
{
    public static IServiceCollection AddInfrastrucure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddDbContext<TaskContext>(options => 
            options.UseSqlite(configuration.GetConnectionString("SQLite")));


        return services;
    }    
}
