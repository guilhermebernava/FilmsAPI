using Domain.Entities;
using FluentValidation;

namespace Domain.Validations
{
    public class ActorValidation : AbstractValidator<Actor>
    {
        public ActorValidation() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id can not be null");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be null");
            RuleFor(x => x.Name).MinimumLength(4).WithMessage("Minimum 4 letters for a name");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age can not be null");
            RuleFor(x => x.Age).LessThan(0).WithMessage("Age must be greater than 0");
        }
    }
}
