using Domain.Entities;
using FilmsAPI.DTOs;
using FilmsAPI.Exceptions;
using FilmsAPI.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace FilmsAPI.Services;

public class UserDeleteService : IUserDeleteService
{
    private readonly UserManager<User> _userManager;

    public UserDeleteService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ServiceResponseDto> Execute(string data)
    {
        var user = await _userManager.FindByIdAsync(data);
        var created = await _userManager.DeleteAsync(user);

        if (!created.Succeeded)
        {
            throw new ServicesException("Error in delete USER");
        }

        return new ServiceResponseDto(true);
    }
}
