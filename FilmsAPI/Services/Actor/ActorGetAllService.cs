using Domain.Repositories;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;

namespace FilmsAPI.Services;

public class ActorGetAllService : IActorGetAllService
{
    private readonly IActorRepository _actorRepository;

    public ActorGetAllService(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;
    }


    //TODO: Implementar servicos e testes de ACTORS
    public async Task<ServiceResponseDto> Execute(GetAllModel model)
    {
        var result = await _actorRepository.GetAllAsync(model.Take, model.Page);
        return new ServiceResponseDto(result);
    }
}
