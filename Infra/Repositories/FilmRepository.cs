using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class FilmRepository : Repository<Film>, IFilmRepository
{
    public FilmRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IList<Film>> GetAllFimsFromActorAsync(string actorName)
    {
        try
        {
            var films = await dbSet.Include(_=> _.FilmActors).ThenInclude(_ => _.Actor.Name.ToUpper() ==  actorName.ToUpper()).ToListAsync();
            return films;
        }
        catch (Exception ex)
        {
            throw new ApplicationDbException(ex.Message);
        }
    }

    public async Task<IList<Film>> GetAllFimsFromGenreAsync(string genre)
    {
        try
        {
            var films = await dbSet.Include(_ => _.FilmGenres).ThenInclude(_ => _.Genre.Name.ToUpper() == genre.ToUpper()).ToListAsync();
            return films;
        }
        catch (Exception ex)
        {
            throw new ApplicationDbException(ex.Message);
        }
    }

    public async Task<IList<Film>> GetFilmWithActors(string filmName)
    {
        try
        {
            var films = await dbSet.Include(_ => _.FilmActors).ThenInclude(_ => _.Actor).Where(_ => _.Title.ToUpper() == filmName.ToUpper()).ToListAsync();
            return films;
        }
        catch (Exception ex)
        {
            throw new ApplicationDbException(ex.Message);
        }
    }
}
