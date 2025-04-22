using Application.Dtos.SheduleDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers;

public class SheduleProfile : Profile
{
    public SheduleProfile()
    {
        CreateMap<Shedule, SheduleReadDto>()
            .ForMember(dest => dest.LessonsIds, 
                opt => opt.MapFrom(src => src.Lessons != null 
                    ? src.Lessons.Select(l => l.Id).ToList() 
                    : new List<Guid>()));

        CreateMap<SheduleCreateDto, Shedule>()
            .ForMember(dest => dest.Lessons, opt => opt.Ignore()) 
            .ForMember(dest => dest.Group, opt => opt.Ignore()); 
    }
}