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

        services.AddScoped<IActorGetAllService, ActorGetAllService>();
        services.AddScoped<IActorGetByIdService, ActorGetByIdService>();
        services.AddScoped<IActorCreateService, ActorCreateService>();
        services.AddScoped<IActorDeleteService, ActorDeleteService>();
        services.AddScoped<IActorUpdateService, ActorUpdateService>();

        services.AddScoped<IGenreGetAllService, GenreGetAllService>();
        services.AddScoped<IGenreGetByIdService, GenreGetByIdService>();
        services.AddScoped<IGenreCreateService, GenreCreateService>();
        services.AddScoped<IGenreDeleteService, GenreDeleteService>();
        services.AddScoped<IGenreUpdateService, GenreUpdateService>();
    }
}