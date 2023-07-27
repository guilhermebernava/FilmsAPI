using Domain.Repositories;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;

namespace FilmsAPI.Services;

public class ActorDeleteService : IActorDeleteService
{
    private readonly IActorRepository _actorRepository;

    public ActorDeleteService(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;
    }


    //TODO: Implementar servicos e testes de ACTORS
    public async Task<ServiceResponseDto> Execute(int id)
    {
        await _actorRepository.DeleteByIdAsync(id);
        return new ServiceResponseDto(true);
    }
}
