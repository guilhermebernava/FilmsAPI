using Domain.Entities;
using Domain.Validations;

namespace DomainTests.Validations;

public class ActorValidationTest
{
    [Fact]
    public void ItShouldBeValid()
    {
        var actor = new Actor("Guilherme",25511);
        var validation = new ActorValidation();

        var result = validation.Validate(actor);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void ItShouldNotValidNameLessThan4Characters()
    {
        var actor = new Actor("tes", 25511);
        var validation = new ActorValidation();

        var result = validation.Validate(actor);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
    }

    [Fact]
    public void ItShouldNotValidNullName()
    {
        var actor = new Actor("", 25511);
        var validation = new ActorValidation();

        var result = validation.Validate(actor);

        Assert.False(result.IsValid);
    }

    [Fact]
    public void ItShouldNotValidAgeLessThan0()
    {
        var actor = new Actor("Guilherme", -1);
        var validation = new ActorValidation();

        var result = validation.Validate(actor);

        Assert.False(result.IsValid);
    }
}
