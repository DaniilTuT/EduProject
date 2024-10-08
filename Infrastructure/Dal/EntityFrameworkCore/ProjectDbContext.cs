using Domain.Entities;
using Infrastructure.Dal.EntityFramework.Configurations;
using Infrastructure.Dal.EntityFrameworkCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.EntityFramework;

/// <summary>
/// Контекст базы данных
/// </summary>
public class ProjectDbContext : DbContext
{
    public DbSet<Shedule> Shedules { get; init; }
    public DbSet<Lesson> Lessons { get; init; }

    public ProjectDbContext(DbContextOptions<ProjectDbContext> options, IConfiguration configuration) :
        base(options)
    {
    }

    /// <summary>
    /// Метод применения конфигураций
    /// </summary>
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);
    //
    //     modelBuilder.ApplyConfiguration(new LessonConfiguration());
    //     modelBuilder.ApplyConfiguration(new SheduleConfiguration());
    // }
}