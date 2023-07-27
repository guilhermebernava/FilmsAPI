using Domain.Entities;
using FilmsAPI.DTOs;
using FilmsAPI.Exceptions;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace FilmsAPI.Services;

public class UserLoginService : IUserLoginService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UserLoginService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<ServiceResponseDto> Execute(UserModel data)
    {
        var user = await _userManager.FindByEmailAsync(data.Email);
        var logged = await _signInManager.PasswordSignInAsync(user,data.Password,false, false);

        if (!logged.Succeeded)
        {
            throw new ServicesException("Email or Password is incorrect");
        }

        return new ServiceResponseDto("JWT");
    }
}
