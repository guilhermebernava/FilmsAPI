using FilmsAPI.Interfaces.Services;
using FilmsAPI.Services;

namespace FilmsAPI;

public static class ServicesInector
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IServiceLocator, ServiceLocator>();
    }
}