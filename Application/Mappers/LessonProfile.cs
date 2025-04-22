using Application.Dtos.LessonDtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers;

public class LessonProfile : Profile
{
    public LessonProfile()
    {
        CreateMap<Lesson, LessonReadDto>();

        CreateMap<LessonCreateDto, Lesson>()
            .ForMember(dest => dest.Shedule, opt => opt.Ignore()) 
            .ForMember(dest => dest.Teacher, opt => opt.Ignore());

        CreateMap<LessonUpdateDto, Lesson>()
            .ForMember(dest => dest.Shedule, opt => opt.Ignore()) 
            .ForMember(dest => dest.Teacher, opt => opt.Ignore()); 
    }
}