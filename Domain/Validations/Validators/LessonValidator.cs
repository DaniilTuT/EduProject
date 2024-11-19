using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validations.Validators
{
    public class LessonValidator : AbstractValidator<Lesson>
    {
        public LessonValidator()
        {
            RuleFor(lesson => lesson.Subject.Name)
                .NotEmpty().WithMessage(ValidationMessages.NotNull)
                .Length(0,100).WithMessage(ValidationMessages.WrongLength);

            RuleFor(lesson => lesson.DateRange.StartDate)
                .LessThan(lesson => lesson.DateRange.EndDate)
                .WithMessage(ValidationMessages.WrongTime);

            RuleFor(lesson => lesson.Teacher)
                .NotNull().WithMessage(ValidationMessages.NotNull)
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty);
        }
    }
}