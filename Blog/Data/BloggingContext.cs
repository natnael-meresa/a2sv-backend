using Microsoft.EntityFrameworkCore;

public class BloggingContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
    {
    }
}