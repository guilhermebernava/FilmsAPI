using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Validations;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;

namespace FilmsAPI.Services;

public class ActorUpdateService : IActorUpdateService
{
    private readonly IActorRepository _actorRepository;
    private readonly IMapper _mapper;
    private readonly ActorValidation _validator = new();

    public ActorUpdateService(IActorRepository actorRepository, IMapper mapper)
    {
        _actorRepository = actorRepository;
        _mapper = mapper;
    }


    //TODO: Implementar servicos e testes de ACTORS
    public async Task<ServiceResponseDto> Execute(ActorUpdateModel viewModel)
    {
        var actor = _mapper.Map<Actor>(viewModel.ActorModel);
        var validation = _validator.Validate(actor);

        if (!validation.IsValid)
        {
            var strings = validation.Errors.Select(_ => _.ErrorMessage).ToList();
            return new ServiceResponseDto(strings);
        }

        var entity = await _actorRepository.GetByIdAsync(viewModel.Id);
        _mapper.Map(viewModel.ActorModel, entity);
        var result = await _actorRepository.UpdateAsync(entity);

        if (!result)
        {
            return new ServiceResponseDto(new List<string>() { "Error in update ACTOR in Database" });
        }
        return new ServiceResponseDto(true);

    }
}
