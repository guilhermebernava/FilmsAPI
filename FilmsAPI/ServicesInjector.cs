using FilmsAPI.Services.Implementations.FilmServices;
using FilmsAPI.Services.Interfaces;

namespace FilmsAPI;

public static class ServicesInector
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateService<FilmViewModel>, FilmCreateService>();
    }
}