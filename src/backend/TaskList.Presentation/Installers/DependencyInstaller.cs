using TaskList.Infrastructure.Installers;
using TaskList.Application.Installers;

namespace TaskList.Presentation.Installers;

public static class DependencyInstaller
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastrucure(configuration);
        services.AddApplication();

        return services;
    }    
}
