using FilmsAPI.DTOs;
using FilmsAPI.Models;

namespace FilmsAPI.Services.Interfaces;

public interface IFilmCreateWithActorAndGenre
{
    public Task<ServiceResponseDto<bool>> Create(FilmViewModel viewModel, List<ActorViewModel> actors, List<GenreViewModel> genres);
}
