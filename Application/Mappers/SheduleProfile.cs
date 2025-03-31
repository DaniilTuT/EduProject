using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class SheduleProfile : Profile
    {
        public SheduleProfile()
        {
            CreateMap<Shedule, SheduleReadDto>()
                .ForMember(dest => dest.Lessons, opt => opt.MapFrom(src => src.Lessons ?? new List<Lesson>()));

            CreateMap<SheduleCreateDto, Shedule>()
                .ForCtorParam("lessons", opt => opt.MapFrom(src => src.Lessons ?? new List<Lesson>()));

            CreateMap<SheduleUpdateDto, Shedule>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); // Игнорируем null-значения при обновлении
        }
    }
}