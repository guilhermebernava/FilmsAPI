using FilmsAPI.DTOs;

namespace FilmsAPI.Services.Interfaces;

public interface ICreateService<T>
{
    public Task<ServiceResponseDto<bool>> Create(T viewModel);
}
