using Domain.Repositories;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;

namespace FilmsAPI.Services;

public class FilmGetAllService : IFilmGetAllService
{
    private readonly IFilmRepository _filmRepository;

    public FilmGetAllService(IFilmRepository filmRepository)
    {
        _filmRepository = filmRepository;
    }

    public async Task<ServiceResponseDto> Execute(FilmGetAllModel model)
    {
        var films = await _filmRepository.GetAllAsync(model.Take,model.Page);
        return new ServiceResponseDto(films);
    }
}
