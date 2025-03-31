using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Dal.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories;

public class SheduleRepository : ISheduleRepository
{
    private readonly ProjectDbContext _projectDbContext;

    public SheduleRepository(ProjectDbContext projectDbContext)
    {
        _projectDbContext = projectDbContext;
    }

    public Shedule? GetById(Guid id)
    {
        var shedule = _projectDbContext.Shedules.FirstOrDefault(x => x.Id == id);
        return shedule;
    }

    public List<Shedule> GetAll()
    {
        var shedules = _projectDbContext.Shedules.ToList();
        return shedules;
    }
    

    public void Create(Shedule entity)
    {
        _projectDbContext.Shedules.AddAsync(entity);
        _projectDbContext.SaveChangesAsync();
    }

    public bool Update(Shedule entity)
    {
        _projectDbContext.Entry(entity).State = EntityState.Modified;
        _projectDbContext.SaveChangesAsync();
        return true;
    }

    public void Delete(Shedule entity)
    {
        var entitys = _projectDbContext.Shedules.Find(entity.Id);
        _projectDbContext.Shedules.Remove(entitys);
        _projectDbContext.SaveChangesAsync();
    }
    
    
}