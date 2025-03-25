using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validations.Validators;

public class UserValidator:AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Name)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .Length(3,20).WithMessage(ValidationMessages.WrongLength);
        RuleFor(user => user.Email)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .NotNull().WithMessage(ValidationMessages.NotNull)
            .EmailAddress().WithMessage(ValidationMessages.WrongEmail);
        RuleFor(user => user.Group)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .NotNull().WithMessage(ValidationMessages.NotNull);
    }
}