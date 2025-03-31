using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFrameworkCore.Configurations;

public class SheduleConfiguration : IEntityTypeConfiguration<Shedule>
{
    public void Configure(EntityTypeBuilder<Shedule> builder)
    {
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Id)
            .HasColumnName("Id")
            .IsRequired();
        
        builder.Property(l => l.Day)
            .IsRequired()
            .HasColumnName("Day")
            .HasColumnType("dayofweek");

        builder.Property(s => s.IsOddWeek)
            .IsRequired()
            .HasColumnName("IsOddWeek");
        
        builder.HasMany(s => s.Lessons)
            .WithOne(l => l.Shedule)
            .HasForeignKey(l => l.SheduleId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(s => s.Group)
            .WithMany(g => g.Shedules)
            .HasForeignKey(s => s.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}