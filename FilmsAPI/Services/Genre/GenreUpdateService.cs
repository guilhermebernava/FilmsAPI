using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Validations;
using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using Infra.Repositories;

namespace FilmsAPI.Services;

public class GenreUpdateService : IGenreUpdateService
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;
    private readonly GenreValidation _validator = new();

    public GenreUpdateService(IGenreRepository genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponseDto> Execute(GenreUpdateModel viewModel)
    {
        var genre = new Genre(viewModel.Name);
        var validation = _validator.Validate(genre);

        if (!validation.IsValid)
        {
            var strings = validation.Errors.Select(_ => _.ErrorMessage).ToList();
            return new ServiceResponseDto(strings);
        }

        var entity = await _genreRepository.GetByIdAsync(viewModel.Id);
        _mapper.Map(genre, entity);
        var result = await _genreRepository.UpdateAsync(entity);

        if (!result)
        {
            return new ServiceResponseDto(new List<string>() { "Error in update GENRE in Database" });
        }
        return new ServiceResponseDto(true);

    }
}
