using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
{

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAsync([FromServices] IGenreCreateService service, [FromBody] GenreModel viewModel)
    {
        var result = await service.Execute(viewModel);
        if (result.IsValid)
        {
            return Created(nameof(GetAllAsync), viewModel);

        }
        return BadRequest(result.Errors);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateAsync([FromServices] IGenreUpdateService service, [FromBody] GenreUpdateModel viewModel)
    {
        var result = await service.Execute(viewModel);
        if (result.IsValid)
        {
            return NoContent();

        }
        return BadRequest(result.Errors);
    }

    [HttpGet]
    [Authorize]
    [Route("GetById")]
    public async Task<IActionResult> GetByIdAsync([FromServices] IGenreGetByIdService service, [FromQuery] int id)
    {
        var result = await service.Execute(id);
        if (result.IsValid)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Errors);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllAsync([FromServices] IGenreGetAllService service, [FromQuery] int take = 20, int page = 1)
    {
        var result = await service.Execute(new GetAllModel(take, page));
        if (result.IsValid)
        {
            return Ok(result.Value);

        }
        return BadRequest(result.Errors);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteAsync([FromServices] IGenreDeleteService service, [FromQuery] int id)
    {
        var result = await service.Execute(id);
        if (result.IsValid)
        {
            return NoContent();

        }
        return BadRequest(result.Errors);
    }
}
