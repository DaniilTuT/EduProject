using Application.Dtos.SheduleDtos;
using Application.Dtos.UserDtos;
using Domain.Entities;

namespace Application.Dtos.GroupDtos;

public class GroupReadDto
{
    public Guid Id { get; set; }
    public string GroupName { get; set; }
}