using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromServices] IFilmCreateService service, [FromBody] FilmModel viewModel)
    {
        var result = await service.Execute(viewModel);
        if (result.IsValid)
        {
            return Created(nameof(GetAllAsync), viewModel);

        }
        return BadRequest(result.Errors);
    }

    [HttpPost]
    [Route("AddWithActorsAndGenres")]
    public async Task<IActionResult> AddWithActorsAndGenresAsync([FromServices] IFilmCreateWithActorsAndGenresService service, [FromBody] FilmWithActorsAndGenresModel viewModel)
    {
        var result = await service.Execute(viewModel);
        if (result.IsValid)
        {
            return Created(nameof(GetAllWithActorsAndGenresAsync), viewModel);
        }
        return BadRequest(result.Errors);
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAllAsync([FromServices] IFilmGetAllService service, [FromQuery] int take = 20, [FromQuery] int page = 1)
    {
        var result = await service.Execute(new FilmGetAllModel(take, page));
        return Ok(result.Value);
    }

    [HttpPut]
    public async Task<IActionResult> Updatesync([FromServices] IFilmUpdateService service,[FromBody] FilmUpdateModel viewModel)
    {
        var result = await service.Execute(viewModel);
        if(result.IsValid)
        {
            return NoContent();
        }
        return BadRequest(result.Errors);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromServices] IFilmDeleteService service, [FromBody] int id)
    {
        var result = await service.Execute(id);
        if (result.IsValid)
        {
            return Ok();
        }
        return BadRequest(result.Errors);
    }

    [HttpGet]
    [Route("GetAllWithActorsAndGenres")]
    public async Task<IActionResult> GetAllWithActorsAndGenresAsync([FromServices] IFilmGetWithActorAndGenreService service, [FromQuery] string? filmName)
    {
        var result = await service.Execute(filmName);
        if (result.IsValid)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Errors);
    }

    [HttpGet]
    [Route("GetFilmsByGenre")]
    public async Task<IActionResult> GetFilmsByGenreAsync([FromServices] IFilmGetByGenreService service, [FromQuery] string genre)
    {
        var result = await service.Execute(genre);
        if (result.IsValid)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Errors);
    }

    [HttpGet]
    [Route("GetFilmsByActor")]
    public async Task<IActionResult> GetFilmsByActorAsync([FromServices] IFilmGetByActorService service, [FromQuery] string actorName)
    {
        var result = await service.Execute(actorName);
        if (result.IsValid)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Errors);
    }
}
