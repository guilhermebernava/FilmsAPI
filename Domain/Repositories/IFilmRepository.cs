using Domain.Entities;

namespace Domain.Repositories;

public interface IFilmRepository : IRepository<Film>
{
    public Task<Film> GetFilmWithActorsAndGenresAsync(string filmName);
    public Task<IList<Film>> GetAllFilmWithActorsAndGenresAsync();
    public Task<bool> AddFilmWithActorsAndGenresAsync(Film film, List<Actor> actors, List<Genre> genres);
    public Task<IList<Film>> GetAllFimsFromGenreAsync(string genre);
    public Task<IList<Film>> GetAllFimsFromActorAsync(string actorName);
}
