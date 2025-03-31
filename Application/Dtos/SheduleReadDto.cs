using Domain.Entities;

namespace Application.Dtos;

public class SheduleReadDto
{
    public Guid Id { get; init; }
    public DayOfWeek DayOfWeek { get; init; }
    public Group Group { get; init; }
    public List<Lesson>? Lessons { get; init; }
    public bool IsOddWeek { get; init; }
}