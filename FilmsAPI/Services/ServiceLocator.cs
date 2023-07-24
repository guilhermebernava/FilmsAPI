using AutoMapper;
using Domain.Repositories;
using FilmsAPI.Exceptions;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Services.Film;

namespace FilmsAPI.Services;

public class ServiceLocator : IServiceLocator
{
    private IDictionary<object, object> _services;
    private IMapper _mapper;
    private IFilmRepository _filmRepository;

    public ServiceLocator(IMapper mapper, IFilmRepository filmRepository)
    {
        _mapper = mapper;
        _filmRepository = filmRepository;
        _services = new Dictionary<object, object>
        {
            { typeof(IFilmCreateService), new FilmCreateService(_filmRepository, _mapper) },
            { typeof(IFilmCreateWithActorsAndGenresService), new FilmCreateWithActorAndGenre(_filmRepository, _mapper) },
            { typeof(IFilmGetAllService), new FilmGetAllService(_filmRepository) },
            { typeof(IFilmGetByActorService), new FilmGetByActorService(_filmRepository) },
            { typeof(IFilmGetByGenreService), new FilmGetByGenreService(_filmRepository) },
            { typeof(IFilmDeleteService), new FilmDeleteService(_filmRepository) },
            { typeof(IFilmGetWithActorAndGenreService), new FilmGetWithActorAndGenreService(_filmRepository) },
            { typeof(IFilmUpdateService), new FilmUpdateService(_filmRepository,_mapper) },
        };
    }


    public T GetService<T>()
    {
        try
        {
            return (T)_services[typeof(T)];
        }
        catch (KeyNotFoundException)
        {
            throw new ServicesException("The services is not registred!");
        }
    }
}
