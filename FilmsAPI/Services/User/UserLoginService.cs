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
    private readonly IConfiguration _configuration;

    public UserLoginService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<ServiceResponseDto> Execute(UserModel data)
    {
        var user = await _userManager.FindByEmailAsync(data.Email);
        var logged = await _signInManager.PasswordSignInAsync(user,data.Password,false, false);

        if (!logged.Succeeded)
        {
            throw new ServicesException("Email or Password is incorrect");
        }
        var token = TokenService.GenerateToken(_configuration,user);
        return new ServiceResponseDto(token);
    }
}
