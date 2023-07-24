using Domain.Repositories;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;

namespace FilmsAPI.Services;

public class FilmDeleteService : IFilmDeleteService
{
    public FilmDeleteService(IFilmRepository filmRepository)
    {
        _filmRepository = filmRepository;
    }

    private IFilmRepository _filmRepository { get; set; }

    public async Task<ServiceResponseDto> Execute(int Id)
    {
        var result = await _filmRepository.DeleteByIdAsync(Id);
        return new ServiceResponseDto(result);
    }
}
