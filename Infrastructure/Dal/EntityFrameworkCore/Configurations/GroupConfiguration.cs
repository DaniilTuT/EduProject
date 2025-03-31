using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFrameworkCore.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .IsRequired();
        
        builder.HasMany(x=>x.Shedules)
            .WithOne(x=>x.Group)
            .HasForeignKey(x=>x.Id)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.Users)
            .WithOne(x=>x.Group)
            .HasForeignKey(x=>x.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}