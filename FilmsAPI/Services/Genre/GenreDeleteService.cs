using Domain.Repositories;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;

namespace FilmsAPI.Services;

public class GenreDeleteService : IGenreDeleteService
{
    private readonly IGenreRepository _genreRepository;

    public GenreDeleteService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<ServiceResponseDto> Execute(int id)
    {
        await _genreRepository.DeleteByIdAsync(id);
        return new ServiceResponseDto(true);
    }
}
