using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class BloggingContext : DbContext
    {

        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BloggingContext).Assembly);            
        }
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
    }

}