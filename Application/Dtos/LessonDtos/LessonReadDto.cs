using System.ComponentModel.DataAnnotations;
using Application.Dtos.SheduleDtos;
using Domain.Primitives.Enums;
using Domain.ValueObjects;

namespace Application.Dtos.LessonDtos;

public class LessonReadDto
{
    public Subject Subject { get; set; }

    public Teacher Teacher { get; set; }  

    public TypeOfLesson? TypeOfLesson { get; set; }

    public DateRange DateRange { get; set; } 

}