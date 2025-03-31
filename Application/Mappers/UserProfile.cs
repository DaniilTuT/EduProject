using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
            
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid())) // Генерация нового Id
                .ForMember(dest => dest.IsVerified, opt => opt.MapFrom(src => false)); // По умолчанию IsVerified = false
            
            CreateMap<UserUpdateDto, User>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); // Обновляем только ненулевые значения
        }
    }
}