using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validations.Validators;

public class GroupValidator : AbstractValidator<Group>
{
    public GroupValidator()
    {
        RuleFor(x=> x.GroupName)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty);
    }
}