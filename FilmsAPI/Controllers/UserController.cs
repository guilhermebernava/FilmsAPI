using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromServices] IUserCreateService service, [FromBody] UserModel viewModel)
    {
        var result = await service.Execute(viewModel);
        if (result.IsValid)
        {
            return Created("", viewModel);

        }
        return BadRequest(result.Errors);
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> LoginAsync([FromServices] IUserLoginService service, [FromBody] UserModel viewModel)
    {
        var result = await service.Execute(viewModel);
        if (result.IsValid)
        {
            return Created("", viewModel);

        }
        return BadRequest(result.Errors);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromServices] IUserUpdateService service, [FromBody] UserPasswordModel viewModel)
    {
        var result = await service.Execute(viewModel);
        if (result.IsValid)
        {
            return NoContent();

        }
        return BadRequest(result.Errors);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromServices] IUserDeleteService service, [FromQuery] string id)
    {
        var result = await service.Execute(id);
        if (result.IsValid)
        {
            return NoContent();

        }
        return BadRequest(result.Errors);
    }
}
