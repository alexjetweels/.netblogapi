using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure; 

public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)
{
  public DbSet<User> Users { get; set; }
  public DbSet<Role> Roles { get; set; }
  public DbSet<UserRole> UserRole { get; set; }
  public DbSet<Blog> Blogs { get; set; }
  public DbSet<Comment> Comments { get; set; }
  
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
     modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);
  }
}