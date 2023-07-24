using FilmsAPI.DTOs;

namespace FilmsAPI.Interfaces.Services;

public interface IService<T>
{
    public Task<ServiceResponseDto> Execute(T viewModel);
}

public interface IService
{
    public Task<ServiceResponseDto> Execute();
}
