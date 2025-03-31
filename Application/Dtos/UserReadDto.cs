using Domain.Entities;

namespace Application.Dtos;

public class UserReadDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public Group Group  { get; init; }
    public bool IsVerified { get; init; }
}