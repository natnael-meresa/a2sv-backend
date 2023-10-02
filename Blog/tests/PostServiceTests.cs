using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

public class PostServiceTests
{
    private readonly BloggingContext _context;

    public PostServiceTests()
    {
        _context = ContextGenerator.Generate();
    }

    [Fact]
    public void GetAllPosts_ReturnsAllPosts()
    {
        var posts = new List<Post>
        {
            new Post { PostId = 1, Title = "Post 1", Content = "Content 1" },
            new Post { PostId = 2, Title = "Post 2", Content = "Content 2" }
        };


        _context.Posts.AddRange(posts);
        _context.SaveChanges();


        var postService = new PostService(_context);

        var result = postService.GetAllPosts();

        Assert.Equal(posts.Count, result.Count);
        Assert.Equal(posts[0].Title, result[0].Title);
        Assert.Equal(posts[1].Content, result[1].Content);
    }


    [Fact]
    public void GetPostById_ReturnsPost()
    {
        var postId = 1;
        var post = new Post { PostId = postId, Title = "Post 1", Content = "Content 1" };


        _context.Posts.Add(post);
        _context.SaveChanges();


        var postService = new PostService(_context);

        var result = postService.GetPostById(postId);

        Assert.Equal(post.Title, result.Title);
        Assert.Equal(post.Content, result.Content);
    }

    [Fact]
    public void GetPostById_ThrowsNotFoundException()
    {
        var postId = 1;

        var postService = new PostService(_context);

        var exception = Assert.Throws<NotFoundException>(() => postService.GetPostById(postId));
        Assert.Equal("Post not found.", exception.Message);
    }

    [Fact]
    public void UpdatePost_UpdatesExistingPost()
    {
        var postId = 1;
        var updatedContent = "Updated Content";

        var post = new Post { PostId = postId, Title = "Post 1", Content = "Content 1" };

        _context.Posts.Add(post);
        _context.SaveChanges();

        var postService = new PostService(_context);

        post.Content = updatedContent;
        postService.UpdatePost(post);

        var updatedPost = _context.Posts.Find(postId);
        Assert.Equal(updatedContent, updatedPost.Content);
    }

    [Fact]
    public void DeletePost_RemovesExistingPost()
    {
        var postId = 1;

        var post = new Post { PostId = postId, Title = "Post 1", Content = "Content 1" };

        _context.Posts.Add(post);
        _context.SaveChanges();

        var postService = new PostService(_context);

        postService.DeletePost(postId);

        var deletedPost = _context.Posts.Find(postId);
        Assert.Null(deletedPost);
    }

    [Fact]
    public void DeletePost_ThrowsNotFoundException()
    {
        var postId = 1;

        var postService = new PostService(_context);

        var exception = Assert.Throws<NotFoundException>(() => postService.DeletePost(postId));
        Assert.Equal("Post not found.", exception.Message);
    }

}