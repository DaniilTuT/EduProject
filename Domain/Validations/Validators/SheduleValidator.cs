using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validations.Validators;
public class SheduleValidator: AbstractValidator<Shedule>
{
    /// <summary>
    /// Валидация метода Shedule
    /// </summary>
    public SheduleValidator()
    {
        RuleFor(shedule => shedule.DayOfWeek)
            .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
            .NotNull().WithMessage(ValidationMessages.NotNull);
        RuleFor(shedule => shedule.Lessons)
            .NotNull().WithMessage(ValidationMessages.NotNull);
        RuleFor(shedule => shedule.IsOddWeek)
            .NotNull().WithMessage(ValidationMessages.NotNull);
    }
}