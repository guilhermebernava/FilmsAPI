using Domain.Entities;
using FilmsAPI.DTOs;
using FilmsAPI.Exceptions;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace FilmsAPI.Services;

public class UserCreateService : IUserCreateService
{
    private readonly UserManager<User> _userManager;

    public UserCreateService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ServiceResponseDto> Execute(UserModel data)
    {
        var user = new User() { Email = data.Email, UserName = data.Email };
        var created = await _userManager.CreateAsync(user, data.Password);

        if (!created.Succeeded)
        {
            throw new ServicesException("Error in creating USER");
        }

        return new ServiceResponseDto(true);
    }
}
