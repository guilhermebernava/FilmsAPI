using Domain.Repositories;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;

namespace FilmsAPI.Services.Film;

public class FilmGetAllService : IFilmGetAllService
{
    private IFilmRepository _filmRepository;

    public FilmGetAllService(IFilmRepository filmRepository)
    {
        _filmRepository = filmRepository;
    }

    public async Task<ServiceResponseDto> Execute()
    {
        var films = await _filmRepository.GetAllAsync();
        return new ServiceResponseDto(films);
    }
}
