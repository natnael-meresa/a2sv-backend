using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {

        string connectionString = "Host=localhost;Database=blog;Username=postgres;Password=postgres";
        var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>()
        .UseNpgsql(connectionString);

        var context = new BloggingContext(optionsBuilder.Options);


        var postService = new PostService(context);
        var commentService = new CommentService(context);

        Console.WriteLine("Console Application Started.");
        try
        {
            var newPost = new Post { PostId = 3, Content = "this is content", Title = "new title" };
            postService.CreatePost(newPost);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"cloudn't create new post: {ex.Message}");
        }

        Console.WriteLine("Displaying Posts:");
        postService.DisplayPosts();


        Console.WriteLine("Displaying Post Details:");
        postService.ShowPostDetails(2);
        
        var newComment = new Comment { Text = "New Comment", PostId = 1 };
        commentService.CreateComment(newComment);

        Console.WriteLine("Console Application Finished.");
    }
}