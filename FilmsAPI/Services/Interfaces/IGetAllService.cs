using FilmsAPI.DTOs;

namespace FilmsAPI.Services.Interfaces;

public interface IGetAllService<T>
{
    public Task<ServiceResponseDto<IList<T>>> GetAll();
}
