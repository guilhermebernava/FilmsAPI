using FilmsAPI.DTOs;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;

namespace FilmsAPI.Services;

public class GenreGetAllService : IGenreGetAllService
{
    public Task<ServiceResponseDto> Execute(GetAllModel viewModel)
    {
        throw new NotImplementedException();
    }
}
