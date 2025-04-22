using Application.Dtos.UserDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserReadDto>(); 
        CreateMap<UserCreateDto, User>(); 
        CreateMap<UserUpdateDto, User>(); 
    }
}