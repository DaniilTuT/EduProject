using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validations.Validators;
public class SheduleValidator: AbstractValidator<Shedule>
{
    public SheduleValidator()
    {
        RuleFor(shedule => shedule.Day)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .NotNull().WithMessage(ValidationMessages.NotNull);
        RuleFor(shedule => shedule.Lessons)
            .NotNull().WithMessage(ValidationMessages.NotNull);
        RuleFor(shedule => shedule.IsOddWeek)
            .NotNull().WithMessage(ValidationMessages.NotNull);
        RuleFor(shedule => shedule.Group)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .NotNull().WithMessage(ValidationMessages.NotNull);
    }
}