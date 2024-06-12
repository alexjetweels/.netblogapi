using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class BlogConfiguration: IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.ToTable("Users");
       
        builder.HasKey(u => u.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(x => x.Content)
            .IsRequired();

        builder.Property(x => x.Image)
            .IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasDefaultValue(DateTime.Now);
        
        builder.Property(x => x.UpdatedAt)
            .IsRequired()
            .HasDefaultValue(DateTime.Now);

        builder.HasOne(x => x.User)
            .WithMany(x=> x.Blogs)
            .HasForeignKey(x=> x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}