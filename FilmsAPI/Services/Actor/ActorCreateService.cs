using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Validations;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;

namespace FilmsAPI.Services;

public class ActorCreateService : IActorCreateService
{
    private readonly IActorRepository _actorRepository;
    private readonly IMapper _mapper;
    private readonly ActorValidation _validator = new();

    public ActorCreateService(IActorRepository actorRepository, IMapper mapper)
    {
        _actorRepository = actorRepository;
        _mapper = mapper;
    }


    //TODO: Implementar servicos e testes de ACTORS
    public async Task<ServiceResponseDto> Execute(ActorModel viewModel)
    {
        var entity = _mapper.Map<Actor>(viewModel);
        var validation = _validator.Validate(entity);

        if (!validation.IsValid)
        {
            var strings = validation.Errors.Select(_ => _.ErrorMessage).ToList();
            return new ServiceResponseDto(strings);
        }

        var result = await _actorRepository.AddAsync(entity);

        if (!result)
        {
            return new ServiceResponseDto(new List<string>() { "Error in save ACTOR in Database" });
        }
        return new ServiceResponseDto(true);

    }
}
