using Domain.Entities;
using FilmsAPI.Services;

namespace GenresAPITests.Services;

public class TokenServiceTest
{

    [Fact]
    public void ItShouldGenerateToken()
    {
        var result = TokenService.GenerateToken(new User() { Email = "Guilherme@bernava.com" });
        Assert.NotEmpty(result);
    }
}
