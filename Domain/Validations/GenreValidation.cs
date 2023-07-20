using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class GenreValidation : AbstractValidator<Genre>
{
    public GenreValidation()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id can not be null");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Genre can not be null");
        RuleFor(x => x.Name).MinimumLength(4).WithMessage("Minimum 4 letters for a genre");
    }
}
