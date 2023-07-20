using Domain.Entities;
using Domain.Validations;

namespace DomainTests.Validations;

public class FilmValidationTest
{
    [Fact]
    public void ItShouldIsValid()
    {
        var genre = new Film("Test",90,7.0,"description", DateTime.Now);
        var validation = new FilmValidation();

        var result = validation.Validate(genre);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void ItShouldNotValidDueTitleNull()
    {
        var genre = new Film("", 90, 7.0, "description", DateTime.Now);
        var validation = new FilmValidation();

        var result = validation.Validate(genre);

        Assert.False(result.IsValid);
    }

    [Fact]
    public void ItShouldNotValidDueDescriptionNull()
    {
        var genre = new Film("Title", 90, 7.0, "", DateTime.Now);
        var validation = new FilmValidation();

        var result = validation.Validate(genre);

        Assert.False(result.IsValid);
    }

    [Fact]
    public void ItShouldNotValidDueDurationLessThan0()
    {
        var genre = new Film("Title", -1, 7.0, "Description", DateTime.Now);
        var validation = new FilmValidation();

        var result = validation.Validate(genre);

        Assert.False(result.IsValid);
    }

    [Fact]
    public void ItShouldNotValidDueScoreLessThan0()
    {
        var genre = new Film("Title", 1, -7.0, "", DateTime.Now);
        var validation = new FilmValidation();

        var result = validation.Validate(genre);

        Assert.False(result.IsValid);
    }

}
