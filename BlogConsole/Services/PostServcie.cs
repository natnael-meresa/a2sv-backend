using System.Linq;
using Microsoft.EntityFrameworkCore;
public class PostService
{
    private readonly BloggingContext _dbContext;

    public PostService(BloggingContext context)
    {
        _dbContext = context;
    }

    public List<Post> GetAllPosts()
    {
        return _dbContext.Posts.ToList();
    }

    public void CreatePost(Post post)
    {
        try
        {
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            // Handle the exception or log the error
            throw new Exception("Failed to create the post.", ex);
        }
    }

    public Post GetPostById(int postId)
    {

        var post = _dbContext.Posts.Find(postId);

        if (post == null)
        {
            // Post not found, throw an exception or handle the error
            throw new NotFoundException("Post not found.");
        }

        return post;
    }

    public void UpdatePost(Post post)
    {
        try
        {
            _dbContext.Posts.Update(post);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to update the post.", ex);
        }
    }

    public void DeletePost(int postId)
    {
        var post = _dbContext.Posts.Find(postId);
        if (post == null)
        {
            throw new NotFoundException("Post not found.");
        }

        try
        {
            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to delete the post.", ex);
        }
    }

    public void DisplayPosts()
    {
        var posts = _dbContext.Posts.ToList();

        foreach (var post in posts)
        {
            Console.WriteLine($"Post ID: {post.PostId}");
            Console.WriteLine($"Title: {post.Title}");
            Console.WriteLine($"Content: {post.Content}");
            Console.WriteLine("----------------------------------");
        }
    }

    public void ShowPostDetails(int postId)
    {
        var post = _dbContext.Posts
            .Include(p => p.Comments)
            .FirstOrDefault(p => p.PostId == postId);

        if (post == null)
        {
            Console.WriteLine("Post not found.");
            return;
        }

        Console.WriteLine($"Post ID: {post.PostId}");
        Console.WriteLine($"Title: {post.Title}");
        Console.WriteLine($"Content: {post.Content}");
        Console.WriteLine("Comments:");
        foreach (var comment in post.Comments)
        {
            Console.WriteLine($"-   {comment.Text}");
        }
    }
}