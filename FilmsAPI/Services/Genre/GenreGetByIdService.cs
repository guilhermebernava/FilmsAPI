using Domain.Repositories;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;

namespace FilmsAPI.Services;

public class GenreGetByIdService : IGenreGetByIdService
{
    private readonly IGenreRepository _genreRepository;

    public GenreGetByIdService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<ServiceResponseDto> Execute(int id)
    {
        var result = await _genreRepository.GetByIdAsync(id);
        return new ServiceResponseDto(result);
    }
}
