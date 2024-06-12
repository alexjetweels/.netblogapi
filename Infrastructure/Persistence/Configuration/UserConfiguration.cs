using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
       builder.ToTable("Users");
       
       builder.HasKey(u => u.Id);
       
       builder.Property(x=> x.UserName)
           .IsRequired()
           .HasMaxLength(50)
           .HasColumnType("varchar(50)");
       
       builder.Property(x=> x.Password)
           .IsRequired()
           .HasMaxLength(250)
           .HasColumnType("varchar(250)");
       
       builder.Property(x=> x.Email)
           .IsRequired()
           .HasMaxLength(100)
           .HasColumnType("varchar(100)")
           .HasAnnotation("RegularExpression", @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

       builder.HasMany(x => x.UserRoles)
           .WithOne(ur => ur.User)
           .HasForeignKey(ur => ur.UserId);


    }
}