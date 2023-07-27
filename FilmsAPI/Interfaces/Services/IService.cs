using FilmsAPI.DTOs;

namespace FilmsAPI.Interfaces.Services;

public interface IService<T>
{
    public Task<ServiceResponseDto> Execute(T data);
}

public interface IService
{
    public Task<ServiceResponseDto> Execute();
}
