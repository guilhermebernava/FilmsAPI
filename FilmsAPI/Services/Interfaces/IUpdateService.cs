using FilmsAPI.DTOs;

namespace FilmsAPI.Services.Interfaces;

public interface IUpdateService<T>
{
    public Task<ServiceResponseDto<bool>> Update(T entity, int id);
}
