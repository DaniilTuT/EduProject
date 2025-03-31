using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFrameworkCore.Configurations;

public class VerificationCodeConfiguration : IEntityTypeConfiguration<VerificationCode>
{
    public void Configure(EntityTypeBuilder<VerificationCode> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("Id");
        
        builder.Property(x => x.ExpirationTime)
            .IsRequired()
            .HasColumnName("ExpirationTime");
        
        builder.Property(x => x.Token)
            .IsRequired()
            .HasColumnName("Token");
        
        builder.Property(x=>x.UserId)
            .IsRequired()
            .HasColumnName("UserId");
        
        builder.HasOne(x=>x.User)
            .WithMany(x=>x.VerificationCodes)
            .HasForeignKey(x=>x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
            
    }
}