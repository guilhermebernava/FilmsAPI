using Domain.Repositories;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra;

public static class RepositoryInector
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IActorRepository,ActorRepository>();
        services.AddScoped<IGenreRepository,GenreRepository>();
        services.AddScoped<IFilmRepository,FilmRepository>();
    }
}
