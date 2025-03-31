using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Dal.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly ProjectDbContext _projectDbContext;

    public GroupRepository(ProjectDbContext projectDbContext)
    {
        _projectDbContext = projectDbContext;
    }

    public Group? GetById(Guid id)
    {
        var group = _projectDbContext.Groups.FirstOrDefault(x => x.Id == id);
        return group;
    }

    public List<Group> GetAll()
    {
        var groups = _projectDbContext.Groups.ToList();
        return groups;
    }

    public void Create(Group entity)
    {
        _projectDbContext.Groups.AddAsync(entity);
        _projectDbContext.SaveChangesAsync();
    }

    public bool Update(Group entity)
    {
        _projectDbContext.Groups.Entry(entity).State = EntityState.Modified;
        _projectDbContext.SaveChangesAsync();
        return true;
    }

    public void Delete(Group entity)
    {
        var entitys = _projectDbContext.Groups.Find(entity.Id);
        _projectDbContext.Groups.Remove(entitys);
        _projectDbContext.SaveChangesAsync();
    }
}