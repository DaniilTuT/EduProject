using System.ComponentModel.DataAnnotations;
using Domain.Primitives.Enums;
using Domain.ValueObjects;

namespace Application.Dtos.LessonDtos;

public class LessonUpdateDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Subject Subject { get; set; }

    [Required]
    public Teacher Teacher { get; set; }  

    public TypeOfLesson? TypeOfLesson { get; set; }

    [Required]
    public DateRange DateRange { get; set; } 

    [Required]
    public Guid SheduleId { get; set; }
}