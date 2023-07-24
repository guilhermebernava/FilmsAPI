using Domain.Repositories;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;

namespace FilmsAPI.Services;

public class FilmGetWithActorAndGenreService : IFilmGetWithActorAndGenreService
{
    public FilmGetWithActorAndGenreService(IFilmRepository filmRepository)
    {
        _filmRepository = filmRepository;
    }

    private IFilmRepository _filmRepository { get; set; }

    public async Task<ServiceResponseDto> Execute(string? filmName)
    {
        IList<Domain.Entities.Film> result;
        if (filmName == null)
        {
            result = await _filmRepository.GetAllFilmWithActorsAndGenresAsync();
        }
        else
        {
            result = new List<Domain.Entities.Film>() { await _filmRepository.GetFilmWithActorsAndGenresAsync(filmName) };
        }
        return new ServiceResponseDto(result);
    }
}
