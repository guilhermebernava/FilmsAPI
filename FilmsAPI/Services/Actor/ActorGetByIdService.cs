using Domain.Repositories;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;

namespace FilmsAPI.Services;

public class ActorGetByIdService : IActorGetByIdService
{
    private readonly IActorRepository _actorRepository;

    public ActorGetByIdService(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;
    }


    //TODO: Implementar servicos e testes de ACTORS
    public async Task<ServiceResponseDto> Execute(int id)
    {
        var result = await _actorRepository.GetByIdAsync(id);
        return new ServiceResponseDto(result);
    }
}
