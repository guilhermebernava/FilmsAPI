using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Validations;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;

namespace FilmsAPI.Services;

public class FilmUpdateService : IFilmUpdateService
{

    private IFilmRepository FilmRepository { get; set; }
    private readonly IMapper _mapper;
    private readonly FilmValidation _filmValidator = new();

    public FilmUpdateService(IFilmRepository filmRepository, IMapper mapper)
    {
        FilmRepository = filmRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponseDto> Execute(FilmUpdateModel viewModel)
    {
        var film = _mapper.Map<Film>(viewModel.FilmModel);
        var validation = _filmValidator.Validate(film);

        if (!validation.IsValid)
        {
            var strings = validation.Errors.Select(_ => _.ErrorMessage).ToList();
            return new ServiceResponseDto(strings);
        }

        var filmEntity = await FilmRepository.GetByIdAsync(viewModel.FilmId);
        _mapper.Map(viewModel.FilmModel, filmEntity);
        var result = await FilmRepository.UpdateAsync(filmEntity);

        if (!result)
        {
            return new ServiceResponseDto(new List<string>() { "Error in save FILM in Database" });
        }
        return new ServiceResponseDto(true);
    }
}
