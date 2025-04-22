using System.ComponentModel.DataAnnotations;
using Domain.Primitives.Enums;
using Domain.ValueObjects;

namespace Application.Dtos.LessonDtos;

public class LessonCreateDto
{

    [Required] public Subject Subject { get; set; }

    [Required] public Teacher Teacher { get; set; }

    public TypeOfLesson? TypeOfLesson { get; set; }

    [Required] public DateRange DateRange { get; set; }
}