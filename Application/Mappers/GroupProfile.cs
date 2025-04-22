using Application.Dtos.GroupDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers;

public class GroupProfile : Profile
{
    public GroupProfile()
    {
        CreateMap<Group, GroupReadDto>();
        
        CreateMap<GroupCreateDto, Group>()
            .ForMember(dest => dest.Shedules, opt => opt.Ignore()) 
            .ForMember(dest => dest.Users, opt => opt.Ignore());   

        CreateMap<GroupUpdateDto, Group>()
            .ForMember(dest => dest.Shedules, opt => opt.Ignore()) 
            .ForMember(dest => dest.Users, opt => opt.Ignore());   
    }
}