using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.Dtos;

public class SheduleCreateDto
{
    [Required]
    public DayOfWeek DayOfWeek { get; set; }
    
    [Required]
    public Group Group { get; set; }

    public List<Lesson>? Lessons { get; set; } 

    [Required]
    public bool IsOddWeek { get; set; }
}