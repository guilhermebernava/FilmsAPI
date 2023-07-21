using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Validations;
using FilmsAPI.DTOs;
using FilmsAPI.Models;
using FilmsAPI.Services.Interfaces;

namespace FilmsAPI.Services.Implementations;

public class FilmCreateWithActorAndGenre : IFilmCreateWithActorAndGenre
{
    private IFilmRepository _filmRepository { get; set; }
    private readonly IMapper _mapper;
    private FilmValidation _filmValidator = new FilmValidation();
    private ActorValidation _actorValidator = new ActorValidation();
    private GenreValidation _genreValidator = new GenreValidation();

    public FilmCreateWithActorAndGenre(IFilmRepository filmRepository, IMapper mapper)
    {
        _filmRepository = filmRepository;
        _mapper = mapper;
    }


    public async Task<ServiceResponseDto<bool>> Create(FilmViewModel viewModel, List<ActorViewModel> actors, List<GenreViewModel> genres)
    {
        var film = _mapper.Map<Film>(viewModel);
        var validation = _filmValidator.Validate(film);
        var actorsEntities = new List<Actor>();
        var genreEntities = new List<Genre>();

        if (!validation.IsValid)
        {
            var strings = validation.Errors.Select(_ => _.ErrorMessage).ToList();
            return new ServiceResponseDto<bool>(strings);
        }

        foreach (var actorViewModel in actors)
        {
            var actor = _mapper.Map<Actor>(actorViewModel);
            var actorValidated = _actorValidator.Validate(actor);
            if (!actorValidated.IsValid)
            {
                var strings = actorValidated.Errors.Select(_ => _.ErrorMessage).ToList();
                return new ServiceResponseDto<bool>(strings);
            }
            actorsEntities.Add(actor);
        }

        foreach (var genreViewModel in genres)
        {
            var genre = _mapper.Map<Genre>(genreViewModel);
            var genreValidated = _genreValidator.Validate(genre);
            if (!genreValidated.IsValid)
            {
                var strings = genreValidated.Errors.Select(_ => _.ErrorMessage).ToList();
                return new ServiceResponseDto<bool>(strings);
            }
            genreEntities.Add(genre);
        }


        var result = await _filmRepository.AddFilmWithActorsAndGenresAsync(film, actorsEntities, genreEntities);

        if (!result)
        {
            return new ServiceResponseDto<bool>(new List<string>() { "Error in save FILM in Database" });
        }
        return new ServiceResponseDto<bool>(true);
    }

}
