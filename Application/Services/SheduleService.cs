using Application.Exceptions;
using Application.Interfaces.Repository;
using Domain.Entities;

namespace Application.Services;

public class SheduleService
{
    
    private readonly ISheduleRepository _sheduleRepository;

    public SheduleService(ISheduleRepository sheduleRepository)
    {
        _sheduleRepository = sheduleRepository;
    }


    public Shedule GetSheduleById(Guid sheduleId)
    {
        var shedule = GetByIdOrThrow(sheduleId);
        return shedule;
    }
    
    public List<Shedule> GetAllShedules()
    {
        var shedules = _sheduleRepository.GetAll();
        return shedules;
    }

    public Shedule CreateShedule(Shedule shedule)
    {
        _sheduleRepository.Create(shedule);
        return shedule;
    }
    
    public Shedule UpdateShedule(Shedule shedule)
    {
        var shed = GetByIdOrThrow(shedule.Id);
        shed.Update(shedule);
        _sheduleRepository.Update(shed);
        return shedule;
    }
    
    
    public void Delete(Guid id)
    {
        var shedule = GetByIdOrThrow(id);
        _sheduleRepository.Delete(shedule);
    }
    
    private Shedule GetByIdOrThrow(Guid id)
    {
        var person = _sheduleRepository.GetById(id);
        if (person == null)
        {
            throw new EntityNotFoundException<Shedule>(nameof(Shedule.Id), id.ToString());
        }

        return person;
    }
}