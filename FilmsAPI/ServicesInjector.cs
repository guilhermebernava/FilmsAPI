using FilmsAPI.Interfaces.Services;
using FilmsAPI.Services;

namespace FilmsAPI;

public static class ServicesInector
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IFilmGetByActorService, FilmGetByActorService>();
        services.AddScoped<IFilmGetWithActorAndGenreService, FilmGetWithActorAndGenreService>();
        services.AddScoped<IFilmGetByGenreService, FilmGetByGenreService>();
        services.AddScoped<IFilmDeleteService, FilmDeleteService>();
        services.AddScoped<IFilmCreateService, FilmCreateService>();
        services.AddScoped<IFilmCreateWithActorsAndGenresService, FilmCreateWithActorAndGenreService>();
        services.AddScoped<IFilmUpdateService, FilmUpdateService>();
        services.AddScoped<IFilmGetAllService, FilmGetAllService>();
    }
}