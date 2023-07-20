using Domain.Entities;
using Domain.Validations;

namespace DomainTests.Validations;

public class GenreValidationTest
{
    [Fact]
    public void ItShouldIsValid()
    {
        var genre = new Genre("Comedy");
        var validation = new GenreValidation();

        var result = validation.Validate(genre);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void ItShouldNotValidDueNull()
    {
        var genre = new Genre("");
        var validation = new GenreValidation();

        var result = validation.Validate(genre);

        Assert.False(result.IsValid);
    }

    [Fact]
    public void ItShouldNotValidDueLenght()
    {
        var genre = new Genre("C");
        var validation = new GenreValidation();

        var result = validation.Validate(genre);

        Assert.False(result.IsValid);
    }

}
