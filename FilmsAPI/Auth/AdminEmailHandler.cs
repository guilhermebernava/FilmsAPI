using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FilmsAPI.Auth;

public class AdminEmailAuthorization : AuthorizationHandler<AdminEmail>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AdminEmailAuthorization(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminEmail requirement)
    {
        var emailClaim = context
            .User.FindFirst(claim =>
            claim.Type == ClaimTypes.Email);
        _ = context.User.Identity;
        if(emailClaim == null)
        {
            return Task.CompletedTask;
        }

        if(emailClaim.Value == requirement.Email)
        {
            context.Succeed(requirement);
        }
        if(_httpContextAccessor.HttpContext != null)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
        }
        
        context.Fail();
        return Task.CompletedTask;
    }
}
