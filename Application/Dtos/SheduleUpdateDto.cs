using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.Dtos;

public class SheduleUpdateDto
{
    [Required]
    public Guid Id { get; set; }

    public DayOfWeek? DayOfWeek { get; set; }

    public List<Lesson>? Lessons { get; set; }
    
    [Required]
    public Group Group { get; set; }

    public bool? IsOddWeek { get; set; }
}