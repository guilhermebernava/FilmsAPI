using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ActorController : ControllerBase
{

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAsync([FromServices] IActorCreateService service, [FromBody] ActorModel viewModel)
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
    public async Task<IActionResult> UpdateAsync([FromServices] IActorUpdateService service, [FromBody] ActorUpdateModel viewModel)
    {
        var result = await service.Execute(viewModel);
        if (result.IsValid)
        {
            return NoContent();

        }
        return BadRequest(result.Errors);
    }

    [HttpGet]
    [Route("GetById")]
    [Authorize]
    public async Task<IActionResult> GetByIdAsync([FromServices] IActorGetByIdService service, [FromQuery] int id)
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
    public async Task<IActionResult> GetAllAsync([FromServices] IActorGetAllService service, [FromQuery] int take = 20, int page = 1)
    {
        var result = await service.Execute(new GetAllModel(take,page));
        if (result.IsValid)
        {
            return Ok(result.Value);

        }
        return BadRequest(result.Errors);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteAsync([FromServices] IActorDeleteService service, [FromQuery] int id)
    {
        var result = await service.Execute(id);
        if (result.IsValid)
        {
            return NoContent();

        }
        return BadRequest(result.Errors);
    }
}
