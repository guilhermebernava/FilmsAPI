using Domain.Entities;
using FluentValidation;

namespace Domain.Validations;

public class FilmValidation : AbstractValidator<Film>
{
    public FilmValidation()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id can not be null");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title can not be null");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description can not be null");
        RuleFor(x => x.Duration).NotEmpty().WithMessage("Duration can not be null");
        RuleFor(x => x.Duration).LessThan(0).WithMessage("Duration must be greater than 0");
        RuleFor(x => x.Score).NotEmpty().WithMessage("Duration can not be null");
        RuleFor(x => x.Score).LessThan(0).WithMessage("Score must be greater than 0");
        RuleFor(x => x.ReleaseDate).NotEmpty().WithMessage("ReleaseDate can not be null");
    }
}
