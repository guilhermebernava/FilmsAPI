using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Validations;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;

namespace FilmsAPI.Services;

public class FilmCreateService : IFilmCreateService
{
    private IFilmRepository _filmRepository { get; set; }
    private readonly IMapper _mapper;
    private FilmValidation _filmValidator = new FilmValidation();

    public FilmCreateService(IFilmRepository filmRepository, IMapper mapper)
    {
        _filmRepository = filmRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponseDto> Execute(FilmViewModel viewModel)
    {
        var film = _mapper.Map<Domain.Entities.Film>(viewModel);
        var validation = _filmValidator.Validate(film);

        if (!validation.IsValid)
        {
            var strings = validation.Errors.Select(_ => _.ErrorMessage).ToList();
            return new ServiceResponseDto(strings);
        }

        var result = await _filmRepository.AddAsync(film);

        if (!result)
        {
            return new ServiceResponseDto(new List<string>() { "Error in save FILM in Database" });
        }
        return new ServiceResponseDto(true);
    }
}
