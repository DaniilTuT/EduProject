using Domain.Entities;

namespace Application.Dtos.UserDtos;

public class UserReadDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public Guid GroupId  { get; init; }
    public bool IsVerified { get; init; }
}