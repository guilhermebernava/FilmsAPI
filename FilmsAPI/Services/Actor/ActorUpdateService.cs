using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;

namespace FilmsAPI.Services;

public class ActorUpdateService : IActorUpdateService
{
    public Task<ServiceResponseDto> Execute(ActorUpdateModel viewModel)
    {
        throw new NotImplementedException();
    }
}
