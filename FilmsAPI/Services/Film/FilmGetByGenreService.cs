using Domain.Repositories;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;

namespace FilmsAPI.Services;

public class FilmGetByGenreService : IFilmGetByGenreService
{
    public FilmGetByGenreService(IFilmRepository filmRepository)
    {
        _filmRepository = filmRepository;
    }

    private IFilmRepository _filmRepository { get; set; }

    public async Task<ServiceResponseDto> Execute(string genre)
    {
        var result = await _filmRepository.GetAllFimsFromGenreAsync(genre);
        return new ServiceResponseDto(result);
    }
}
