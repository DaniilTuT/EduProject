using Domain.Entities;

namespace Application.Dtos.SheduleDtos;

public class SheduleReadDto
{
    public Guid Id { get; init; }
    public DayOfWeek DayOfWeek { get; init; }
    public Guid GroupId { get; init; }
    public List<Guid>? LessonsIds { get; init; }
    public bool IsOddWeek { get; init; }
}