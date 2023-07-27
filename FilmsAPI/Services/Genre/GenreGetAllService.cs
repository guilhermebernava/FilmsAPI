using Domain.Repositories;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;

namespace FilmsAPI.Services;

public class GenreGetAllService : IGenreGetAllService
{
    private readonly IGenreRepository _genreRepository;

    public GenreGetAllService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<ServiceResponseDto> Execute(GetAllModel model)
    {
        var result = await _genreRepository.GetAllAsync(model.Take, model.Page);
        return new ServiceResponseDto(result);
    }
}
