using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Dal.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ProjectDbContext _projectDbContext;

    public UserRepository(ProjectDbContext projectDbContext)
    {
        _projectDbContext = projectDbContext;
    }

    public User GetById(Guid id)
    {
        var shedule = _projectDbContext.Users.FirstOrDefault(x => x.Id == id);
        return shedule;
    }

    public List<User> GetAll()
    {
        var shedules = _projectDbContext.Users.ToList();
        return shedules;
    }
    

    public void Create(User entity)
    {
        _projectDbContext.Users.AddAsync(entity);
        _projectDbContext.SaveChangesAsync();
    }

    public bool Update(User entity)
    {
        _projectDbContext.Entry(entity).State = EntityState.Modified;
        _projectDbContext.SaveChangesAsync();
        return true;
    }

    public void Delete(User entity)
    {
        var entitys = _projectDbContext.Users.Find(entity.Id);
        _projectDbContext.Users.Remove(entitys);
        _projectDbContext.SaveChangesAsync();
    }
    
}