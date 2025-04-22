using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.Dtos.SheduleDtos;

public class SheduleUpdateDto
{
    [Required]
    public Guid Id { get; set; }

    public DayOfWeek? DayOfWeek { get; set; }

    public List<Guid>? LessonsIds { get; set; }
    
    [Required]
    public Guid GroupId { get; set; }

    public bool? IsOddWeek { get; set; }
}