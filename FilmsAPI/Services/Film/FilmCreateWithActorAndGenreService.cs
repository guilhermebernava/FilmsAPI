using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Validations;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;

namespace FilmsAPI.Services;

public class FilmCreateWithActorAndGenreService : IFilmCreateWithActorsAndGenresService
{
    private IFilmRepository _filmRepository { get; set; }
    private readonly IMapper _mapper;
    private FilmValidation _filmValidator = new FilmValidation();
    private ActorValidation _actorValidator = new ActorValidation();
    private GenreValidation _genreValidator = new GenreValidation();

    public FilmCreateWithActorAndGenreService(IFilmRepository filmRepository, IMapper mapper)
    {
        _filmRepository = filmRepository;
        _mapper = mapper;
    }


    public async Task<ServiceResponseDto> Execute(FilmWithActorsAndGenresModel viewModel)
    {
        var film = _mapper.Map<Domain.Entities.Film>(viewModel.FilmViewModel);
        var validation = _filmValidator.Validate(film);
        var actorsEntities = new List<Actor>();
        var genreEntities = new List<Genre>();

        if (!validation.IsValid)
        {
            var strings = validation.Errors.Select(_ => _.ErrorMessage).ToList();
            return new ServiceResponseDto(strings);
        }

        foreach (var actorViewModel in viewModel.ActorViewModels)
        {
            var actor = _mapper.Map<Actor>(actorViewModel);
            var actorValidated = _actorValidator.Validate(actor);
            if (!actorValidated.IsValid)
            {
                var strings = actorValidated.Errors.Select(_ => _.ErrorMessage).ToList();
                return new ServiceResponseDto(strings);
            }
            actorsEntities.Add(actor);
        }

        foreach (var genreViewModel in viewModel.GenreViewModels)
        {
            var genre = _mapper.Map<Genre>(genreViewModel);
            var genreValidated = _genreValidator.Validate(genre);
            if (!genreValidated.IsValid)
            {
                var strings = genreValidated.Errors.Select(_ => _.ErrorMessage).ToList();
                return new ServiceResponseDto(strings);
            }
            genreEntities.Add(genre);
        }


        var result = await _filmRepository.AddFilmWithActorsAndGenresAsync(film, actorsEntities, genreEntities);

        if (!result)
        {
            return new ServiceResponseDto(new List<string>() { "Error in save FILM in Database" });
        }
        return new ServiceResponseDto(true);
    }

}
