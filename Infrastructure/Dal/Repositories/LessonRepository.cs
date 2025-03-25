using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories;

public class LessonRepository : ILessonRepository
{
    private readonly ProjectDbContext _projectDbContext;

    public LessonRepository(ProjectDbContext projectDbContext)
    {
        _projectDbContext = projectDbContext;
    }

    public Lesson? GetById(Guid id)
    {
        var lesson = _projectDbContext.Lessons.FirstOrDefault(x => x.Id == id);
        return lesson;
    }

    public List<Lesson> GetAll()
    {
        var lessons = _projectDbContext.Lessons.ToList();
        return lessons;
    }
    

    public void Create(Lesson entity)
    {
        _projectDbContext.Lessons.AddAsync(entity);
        _projectDbContext.SaveChangesAsync();
    }

    public bool Update(Lesson entity)
    {
        _projectDbContext.Entry(entity).State = EntityState.Modified;
        _projectDbContext.SaveChangesAsync();
        return true;
    }

    public void Delete(Lesson entity)
    {
        var entitys = _projectDbContext.Lessons.Find(entity.Id);
        _projectDbContext.Lessons.Remove(entitys);
        _projectDbContext.SaveChangesAsync();
    }
    
}