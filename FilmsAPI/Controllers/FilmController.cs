using Domain.Entities;
using FilmsAPI.Models;
using FilmsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmController : ControllerBase
{
    private readonly ICreateService<FilmViewModel> _createService;
    private readonly IGetAllService<Film> _getAllService;
    private readonly IFilmCreateWithActorAndGenre _filmCreateWithActorAndGenre;

    //TODO: Terminar de criar os serviços para o ENDPOINT

    public FilmController(ICreateService<FilmViewModel> createService, IFilmCreateWithActorAndGenre filmCreateWithActorAndGenre, IGetAllService<Film> getAllService)
    {
        _createService = createService;
        _filmCreateWithActorAndGenre = filmCreateWithActorAndGenre;
        _getAllService = getAllService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] FilmViewModel viewModel)
    {
        var result = await _createService.Create(viewModel);

        if (result.IsValid)
        {
            return Ok();

        }
        return BadRequest(result.Errors);
    }

    [HttpPost]
    [Route("AddWithActorsAndGenres")]
    public async Task<IActionResult> AddWithActorsAndGenresAsync([FromBody] FilmViewModel viewModel, List<ActorViewModel> actors, List<GenreViewModel> genres)
    {
        var result = await _filmCreateWithActorAndGenre.Create(viewModel, actors, genres);

        if (result.IsValid)
        {
            return Ok();
        }
        return BadRequest(result.Errors);
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _getAllService.GetAll();
        return Ok(result.Value);
    }

    //[HttpPut]
    //public async Task<IActionResult> Updatesync([FromBody] int id, FilmViewModel viewModel)
    //{
    //    var validation = new FilmValidation();
    //    var film = new Film(viewModel.Title, viewModel.Duration, viewModel.Score, viewModel.Description, viewModel.ReleaseDate);
    //    var validated = validation.Validate(film);

    //    if (!validated.IsValid)
    //    {
    //        return BadRequest(validated.Errors);
    //    }

    //    var entityFilm = await _filmRepository.GetByIdAsync(id);
    //    entityFilm.Duration = viewModel.Duration;
    //    entityFilm.Score = viewModel.Score;
    //    entityFilm.Description = viewModel.Description;
    //    entityFilm.Title = viewModel.Title;
    //    entityFilm.ReleaseDate = viewModel.ReleaseDate;

    //    var result = await _filmRepository.UpdateAsync(entityFilm);

    //    if(result) { return Ok(); }
    //    return BadRequest("Error in update film");
    //}

    //[HttpDelete]
    //public async Task<IActionResult> DeleteAsync([FromBody] int id)
    //{
    //    var result = await _filmRepository.DeleteByIdAsync(id);
    //    if (result) { return Ok(); }
    //    return BadRequest("Error in delete film");
    //}

    //[HttpGet]
    //public async Task<IActionResult> GetAll()
    //{
    //    var films = await _filmRepository.GetAllAsync();
    //    return Ok(films); 
    //}

    //[HttpGet]
    //[Route("GetAllWithActorsAndGenres")]
    //public async Task<IActionResult> GetAllWithActorsAndGenres()
    //{
    //    var films = await _filmRepository.GetAllFilmWithActorsAndGenresAsync();
    //    return Ok(films);
    //}

    //[HttpGet]
    //[Route("GetWithActorsAndGenres")]
    //public async Task<IActionResult> GetAllWithActorsAndGenres([FromQuery] string filmName)
    //{
    //    var film = await _filmRepository.GetFilmWithActorsAndGenresAsync(filmName);
    //    return Ok(film);
    //}
}
