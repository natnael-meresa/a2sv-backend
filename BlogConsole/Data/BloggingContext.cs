using Microsoft.EntityFrameworkCore;


public class BloggingContext : DbContext
{

    public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<Comment> Comments { get; set;}  = null!;


    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {

    //     string connectionString = "Host=localhost;Database=blog;Username=postgres;Password=postgres";

    //     optionsBuilder.UseNpgsql(connectionString); // Replace with your PostgreSQL connection string
    // }
}