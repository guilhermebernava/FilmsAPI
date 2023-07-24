using Domain.Repositories;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;

namespace FilmsAPI.Services;

public class FilmGetByActorService : IFilmGetByActorService
{
    public FilmGetByActorService(IFilmRepository filmRepository)
    {
        _filmRepository = filmRepository;
    }

    private IFilmRepository _filmRepository { get; set; }

    public async Task<ServiceResponseDto> Execute(string actorName)
    {
        var result = await _filmRepository.GetAllFimsFromActorAsync(actorName);
        return new ServiceResponseDto(result);
    }
}
