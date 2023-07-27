using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;

//Diz que e um controller da API
[ApiController]
//Vai pegar o nome do controller antes da palavra CONTROLLER
[Route("[controller]")]
public class FilmController : ControllerBase
{
    //Diz qual é o VERBO HTTP que esse metodo vai representar
    [HttpPost]
    [Authorize]
    //[FromServices] ele está indo buscar nas DI alguma coisa que implemente essa inteface
    //ele sempre ira chamar isso quando esse metodo for chamado por alguma request
    //[FromBody] esta dizendo explicitamente que esse dado vai vir do corpo da requisicao
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
    [Authorize]
    //Diz especificamente qual é a rota, lembrando que a rota base
    //e o nome do controller, nesse caso é FILM
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
    [Authorize]
    [Route("GetAll")]
    //[FromQuery] esta dizendo que esses parametros irao vir de parametros de QUERY da URL
    public async Task<IActionResult> GetAllAsync([FromServices] IFilmGetAllService service, [FromQuery] int take = 20, [FromQuery] int page = 1)
    {
        var result = await service.Execute(new GetAllModel(take, page));
        return Ok(result.Value);
    }

    [HttpPut]
    [Authorize]
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
    [Authorize]
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
    [Authorize]
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
    [Authorize]
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
    [Authorize]
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
