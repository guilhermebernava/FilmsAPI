using Microsoft.AspNetCore.Authorization;

namespace FilmsAPI.Auth;

public class AdminEmail : IAuthorizationRequirement
{
    public AdminEmail(string email)
    {
        Email = email;
    }

    public string Email { get; set; }
}
