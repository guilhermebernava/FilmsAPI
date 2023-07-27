using Domain.Entities;
using FilmsAPI.DTOs;
using FilmsAPI.Exceptions;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace FilmsAPI.Services;

public class UserUpdateService : IUserUpdateService
{
    private readonly UserManager<User> _userManager;

    public UserUpdateService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ServiceResponseDto> Execute(UserPasswordModel data)
    {
        var user = await _userManager.FindByIdAsync(data.Id);
        var created = await _userManager.ChangePasswordAsync(user, data.Password, data.NewPassword);

        if (!created.Succeeded)
        {
            throw new ServicesException("Error in update password from this USER");
        }

        return new ServiceResponseDto(true);
    }
}
