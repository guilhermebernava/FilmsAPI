using FilmsAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FilmsAPI.Services.Interfaces;

public interface IDeleteService
{
    public Task<ServiceResponseDto<bool>> Delete(int id);
}
