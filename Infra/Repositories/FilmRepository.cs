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

    public async Task<bool> AddFilmWithActorsAndGenresAsync(Film film, List<Actor> actors, List<Genre> genres)
    {
        try
        {
            await dbSet.AddAsync(film);
            await SaveAsync();

            var filmEntity = await dbSet.FirstOrDefaultAsync(_ => _.Title == film.Title);

            if (filmEntity == null)
            {
                throw new NotFoundException("Not found film in DB");
            }

            await _AddFilmActors(actors, filmEntity);
            await _AddFilmGenres(genres, filmEntity);

            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationDbException(ex.Message);
        }
    }

    public async Task<IList<Film>> GetAllFimsFromActorAsync(string actorName)
    {
        try
        {
            var films = await dbSet.Include(_ => _.FilmActors).ThenInclude(_ => _.Actor).Where( _ => _.FilmActors.Any( _=> _.Actor.Name.ToUpper() == actorName.ToUpper())).ToListAsync();
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
            var films = await dbSet.Include(_ => _.FilmGenres).ThenInclude(_ => _.Genre).Where(_ => _.FilmGenres.Any(_ => _.Genre.Name.ToUpper() == genre.ToUpper())).ToListAsync();
            return films;
        }
        catch (Exception ex)
        {
            throw new ApplicationDbException(ex.Message);
        }
    }

    public async Task<Film> GetFilmWithActorsAndGenresAsync(string filmName)
    {
        try
        {
            var film = await dbSet.Include(_ => _.FilmActors).ThenInclude(_ => _.Actor).Include(_=> _.FilmGenres).ThenInclude(_ => _.Genre).Where(_ => _.Title.ToUpper() == filmName.ToUpper()).FirstOrDefaultAsync();

            if(film == null)
            {
                throw new NotFoundException($"Can not find this film - {filmName}");
            }

            return film;
        }
        catch (Exception ex)
        {
            throw new ApplicationDbException(ex.Message);
        }
    }

    public async Task<IList<Film>> GetAllFilmWithActorsAndGenresAsync()
    {
        try
        {
            var films = await dbSet.Include(_ => _.FilmActors).ThenInclude(_ => _.Actor).Include(_ => _.FilmGenres).ThenInclude(_ => _.Genre).ToListAsync();
            return films;
        }
        catch (Exception ex)
        {
            throw new ApplicationDbException(ex.Message);
        }
    }

    #region PRIVATE_METHODS
    private async Task _AddFilmGenres(List<Genre> genres, Film filmEntity)
    {
        await Task.Run(async () =>
        {
            var genreDbSet = _dbContext.Set<Genre>();
            var filmGenresDbSet = _dbContext.Set<FilmGenre>();

            foreach (var genre in genres)
            {
                var genreEntity = await genreDbSet.FirstOrDefaultAsync(_ => _.Name == genre.Name);

                if (genreEntity == null)
                {
                    await genreDbSet.AddAsync(genre);
                    await SaveAsync();
                    genreEntity = await genreDbSet.FirstAsync(_ => _.Name == genre.Name);
                }

                await filmGenresDbSet.AddAsync(new FilmGenre() { Genre = genreEntity, Film = filmEntity });
                await SaveAsync();
            }
        });
    }

    private async Task _AddFilmActors(List<Actor> actors, Film filmEntity)
    {
        await Task.Run(async () =>
        {
            var filmActrosDbSet = _dbContext.Set<FilmActor>();
            var actorDbSet = _dbContext.Set<Actor>();

            foreach (var actor in actors)
            {
                var actorEntity = await actorDbSet.FirstOrDefaultAsync(_ => _.Name == actor.Name && _.Age == actor.Age);

                if (actorEntity == null)
                {
                    await actorDbSet.AddAsync(actor);
                    await SaveAsync();
                   actorEntity =  await actorDbSet.FirstAsync(_ => _.Name == actor.Name && _.Age == actor.Age);
                }
                await filmActrosDbSet.AddAsync(new FilmActor() { Actor = actorEntity, Film = filmEntity });
                await SaveAsync();
            }
        });
    }
    #endregion
}
