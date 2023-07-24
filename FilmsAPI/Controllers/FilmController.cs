using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmController : ControllerBase
{
    private readonly IServiceLocator _serviceLocator;

    public FilmController(IServiceLocator serviceLocator)
    {
        _serviceLocator = serviceLocator;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] FilmViewModel viewModel)
    {
        var service = _serviceLocator.GetService<IFilmCreateService>();
        var result = await service.Execute(viewModel);

        if (result.IsValid)
        {
            return Ok();

        }
        return BadRequest(result.Errors);
    }

    [HttpPost]
    [Route("AddWithActorsAndGenres")]
    public async Task<IActionResult> AddWithActorsAndGenresAsync([FromBody] FilmWithActorsAndGenresViewModel viewModel)
    {
        var service = _serviceLocator.GetService<IFilmCreateWithActorsAndGenresService>();
        var result = await service.Execute(viewModel);

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
        var service = _serviceLocator.GetService<IFilmGetAllService>();
        var result = await service.Execute();
        return Ok(result.Value);
    }

    [HttpPut]
    public async Task<IActionResult> Updatesync([FromBody] FilmUpdateViewModel viewModel)
    {
        var service = _serviceLocator.GetService<IFilmUpdateService>();
        var result = await service.Execute(viewModel);

        if(result.IsValid)
        {
            return Ok();
        }
        return BadRequest(result.Errors);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] int id)
    {
        var service = _serviceLocator.GetService<IFilmDeleteService>();
        var result = await service.Execute(id);

        if (result.IsValid)
        {
            return Ok();
        }
        return BadRequest(result.Errors);
    }

    [HttpGet]
    [Route("GetAllWithActorsAndGenres")]
    public async Task<IActionResult> GetAllWithActorsAndGenresAsync([FromQuery] string? filmName)
    {
        var service = _serviceLocator.GetService<IFilmGetWithActorAndGenreService>();
        var result = await service.Execute(filmName);

        if (result.IsValid)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Errors);
    }

    [HttpGet]
    [Route("GetFilmsByGenre")]
    public async Task<IActionResult> GetFilmsByGenreAsync([FromQuery] string genre)
    {
        var service = _serviceLocator.GetService<IFilmGetByGenreService>();
        var result = await service.Execute(genre);

        if (result.IsValid)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Errors);
    }

    [HttpGet]
    [Route("GetFilmsByActor")]
    public async Task<IActionResult> GetFilmsByActorAsync([FromQuery] string actorName)
    {
        var service = _serviceLocator.GetService<IFilmGetByActorService>();
        var result = await service.Execute(actorName);

        if (result.IsValid)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Errors);
    }
}
