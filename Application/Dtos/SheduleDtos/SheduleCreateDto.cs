using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.Dtos.SheduleDtos;

public class SheduleCreateDto
{
    [Required]
    public DayOfWeek DayOfWeek { get; set; }
    
    [Required]
    public Guid GroupId { get; set; }

    public List<Guid>? LessonsIds { get; set; } 

    [Required]
    public bool IsOddWeek { get; set; }
}