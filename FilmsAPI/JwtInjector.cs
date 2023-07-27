using FilmsAPI.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FilmsAPI;

public static class JwtInector
{
    public static void AddJwt(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(options =>
        {
            //Esta dizendo o que JWT Bearer vai utilizar para validar o TOKEN
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("72jasdnSADAS934hsaluif-056**/5540++54")),
                ValidateAudience = false,
                ValidateIssuer = false,
                
                ClockSkew = TimeSpan.Zero
            };
        });

        services.AddSingleton<IAuthorizationHandler, AdminEmailAuthorization>();

        //Adiciona a POLICY de autorazição e autenticação
        services.AddAuthorization(options =>
        {
            var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
                 JwtBearerDefaults.AuthenticationScheme);

            defaultAuthorizationPolicyBuilder =
                defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();

            options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();

            options.AddPolicy("EmailAdmin", policy => policy.AddRequirements(new AdminEmail("a@a.com"))) ;
        });
    }
}