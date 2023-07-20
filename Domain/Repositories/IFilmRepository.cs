using Domain.Entities;

namespace Domain.Repositories;

public interface IFilmRepository : IRepository<Film>
{
    public Task<IList<Film>> GetFilmWithActors(string filmName);
    public Task<IList<Film>> GetAllFimsFromGenreAsync(string genre);
    public Task<IList<Film>> GetAllFimsFromActorAsync(string actorName);
}
