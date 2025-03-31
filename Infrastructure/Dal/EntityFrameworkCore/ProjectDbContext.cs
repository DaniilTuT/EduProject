using Domain.Entities;
using Infrastructure.Dal.EntityFrameworkCore.Configurations;
using Microsoft.EntityFrameworkCore;
// using Infrastructure.Dal.EntityFramework.Configurations;
// using Infrastructure.Dal.EntityFrameworkCore.Configurations;

namespace Infrastructure.Dal.EntityFrameworkCore;

/// <summary>
/// Контекст базы данных
/// </summary>
public class ProjectDbContext : DbContext
{
    public DbSet<Shedule> Shedules { get; init; }
    public DbSet<Lesson> Lessons { get; init; }
    public DbSet<User> Users { get; init; }
    public DbSet<Group> Groups { get; init; }
    public DbSet<VerificationCode> VerificationCodes { get; init; }
    

    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) :
        base(options)
    {
    }

    /// <summary>
    /// Метод применения конфигураций
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.ApplyConfiguration(new LessonConfiguration());
    }
}