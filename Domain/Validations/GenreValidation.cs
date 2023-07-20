using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class GenreValidation : AbstractValidator<Genre>
{
    public GenreValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Genre can not be null");
        RuleFor(x => x.Name).MinimumLength(2).WithMessage("Minimum 2 letters for a genre");
    }
}
