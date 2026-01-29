using TaskList.Infrastructure.Installers;
using TaskList.Application.Installers;

namespace TaskList.Presentation.Installers;

public static class DependencyInstaller
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddInfrastrucure();
        services.AddApplication();

        return services;
    }    
}
