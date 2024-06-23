using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure;

public class BlogDbContextFactory: IDesignTimeDbContextFactory<BlogDbContext>
{
    public BlogDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=Blog;User Id=sa;Password=MyStrongPass123;TrustServerCertificate=True;");

        return new BlogDbContext(optionsBuilder.Options);
    }
}