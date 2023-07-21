using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Validations;
using FilmsAPI.DTOs;
using FilmsAPI.Services.Interfaces;

namespace FilmsAPI.Services.Implementations;

public class FilmCreateService : ICreateService<FilmViewModel>
{
    private IFilmRepository _filmRepository { get; set; }
    private readonly IMapper _mapper;
    private FilmValidation _filmValidator = new FilmValidation();

    public FilmCreateService(IFilmRepository filmRepository, IMapper mapper)
    {
        _filmRepository = filmRepository;
        _mapper = mapper;
    }


    public async Task<ServiceResponseDto<bool>> Create(FilmViewModel viewModel)
    {
        var film = _mapper.Map<Film>(viewModel);
        var validation = _filmValidator.Validate(film);

        if (!validation.IsValid)
        {
            var strings = validation.Errors.Select(_ => _.ErrorMessage).ToList();
            return new ServiceResponseDto<bool>(strings);
        }

        var result = await _filmRepository.AddAsync(film);

        if (!result)
        {
            return new ServiceResponseDto<bool>(new List<string>() { "Error in save FILM in Database" });
        }
        return new ServiceResponseDto<bool>(true);
    }
}
