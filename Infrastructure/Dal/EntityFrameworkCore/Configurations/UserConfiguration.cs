using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFrameworkCore.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("Id");

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("email");
        
        builder.HasIndex(x => x.Email)
            .IsUnique();
        
        builder.Property(x => x.GroupId)
            .IsRequired()
            .HasColumnName("groupId");
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("name");

        builder.Property(x => x.IsVerified)
            .HasColumnName("isVerified");
        
        builder.HasOne(x => x.Group)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(x => x.VerificationCodes)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}