using AutoMapper;
using Domain.Repositories;
using Domain.Validations;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;

namespace FilmsAPI.Services;

public class FilmUpdateService : IFilmUpdateService
{

    private IFilmRepository _filmRepository { get; set; }
    private readonly IMapper _mapper;
    private FilmValidation _filmValidator = new FilmValidation();

    public FilmUpdateService(IFilmRepository filmRepository, IMapper mapper)
    {
        _filmRepository = filmRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponseDto> Execute(FilmUpdateModel viewModel)
    {
        var film = _mapper.Map<Domain.Entities.Film>(viewModel.FilmViewModel);
        var validation = _filmValidator.Validate(film);

        if (!validation.IsValid)
        {
            var strings = validation.Errors.Select(_ => _.ErrorMessage).ToList();
            return new ServiceResponseDto(strings);
        }

        var filmEntity = await _filmRepository.GetByIdAsync(viewModel.FilmId);
        filmEntity.Duration = film.Duration;
        filmEntity.Title = film.Title;
        filmEntity.Description = film.Description;
        filmEntity.ReleaseDate = film.ReleaseDate;
        filmEntity.Score = film.Score;

        var result = await _filmRepository.UpdateAsync(filmEntity);

        if (!result)
        {
            return new ServiceResponseDto(new List<string>() { "Error in save FILM in Database" });
        }
        return new ServiceResponseDto(true);
    }
}
