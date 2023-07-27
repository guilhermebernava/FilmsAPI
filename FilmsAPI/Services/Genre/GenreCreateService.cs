using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Validations;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;

namespace FilmsAPI.Services;

public class GenreCreateService : IGenreCreateService
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;
    private readonly GenreValidation _validator = new();

    public GenreCreateService(IGenreRepository genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponseDto> Execute(GenreModel viewModel)
    {
        var entity = _mapper.Map<Genre>(viewModel);
        var validation = _validator.Validate(entity);

        if (!validation.IsValid)
        {
            var strings = validation.Errors.Select(_ => _.ErrorMessage).ToList();
            return new ServiceResponseDto(strings);
        }

        var result = await _genreRepository.AddAsync(entity);

        if (!result)
        {
            return new ServiceResponseDto(new List<string>() { "Error in save GENRE in Database" });
        }
        return new ServiceResponseDto(true);

    }
}
