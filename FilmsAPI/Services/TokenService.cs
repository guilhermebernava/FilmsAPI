using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FilmsAPI.Services;

public static class TokenService
{
    public static string GenerateToken(IConfiguration configuration,User user)
    {
        //está definindo o que vai ter dentro do PAYLOAD do JWT
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("Id", user.Id),
            new Claim("TwoFactorEnabled", user.TwoFactorEnabled.ToString())
        };

        //está criando uma chave para ser adicionada na SIGNGIN 
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

        //vai ser a forma que nosso JWT vai ser validado
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //esta gerando o token
        var token = new JwtSecurityToken(expires: DateTime.Now.AddMinutes(120),claims: claims,signingCredentials: signingCredentials);

        //está devolvendo o token em formato de STRING
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
