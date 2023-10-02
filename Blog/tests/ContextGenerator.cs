using Microsoft.EntityFrameworkCore;

public static class ContextGenerator
{
    public static BloggingContext Generate()
    {
        var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
            
        
        return new BloggingContext(optionsBuilder.Options);
    }
}