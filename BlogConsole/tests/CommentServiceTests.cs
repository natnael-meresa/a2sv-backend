using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

public class CommentServiceTests
{
    private readonly BloggingContext _context;

    public CommentServiceTests()
    {
        _context = ContextGenerator.Generate();
    }


    [Fact]
    public void GetCommentByPostId_ReturnsPost()
    {
        var postId = 1;
        var post = new Post { PostId = postId, Title = "Post 1", Content = "Content 1" };

        _context.Posts.Add(post);
        _context.SaveChanges();


         var comments = new List<Comment>
        {
            new Comment { CommentId = 1, PostId = postId, Text = "comment 1"},
            new Comment { CommentId = 2, PostId = postId, Text = "comment 2"},
        };

        _context.Comments.AddRange(comments);
        _context.SaveChanges();
       


        var commentService = new CommentService(_context);

        var result = commentService.GetCommentsByPostId(postId);


        Assert.Equal(comments.Count, result.Count);
        Assert.Equal(comments[0].CommentId, result[0].CommentId);
        Assert.Equal(comments[1].Text, result[1].Text);
    }

    [Fact]
    public void UpdateComment_UpdatesExistingComment()
    {

        var postId = 1;

        var post = new Post { PostId = postId, Title = "Post 1", Content = "Content 1" };

        _context.Posts.Add(post);
        _context.SaveChanges();

        var commentId = 1;
        var updatedText = "Updated Content";

        var comment = new Comment { CommentId = commentId, PostId=postId, Text = "comment 1"};

        _context.Comments.Add(comment);
        _context.SaveChanges();

        var commentService = new CommentService(_context);

        comment.Text = updatedText;
        commentService.UpdateComment(comment);

        var updatedcomment = _context.Comments.Find(commentId);
        Assert.Equal(updatedText, updatedcomment.Text);
    }

    [Fact]
    public void DeleteComment_RemovesExistingComment()
    {
        var postId = 1;

        var post = new Post { PostId = postId, Title = "Post 1", Content = "Content 1" };

        _context.Posts.Add(post);
        _context.SaveChanges();


        var commentId = 1;
        var comment = new Comment { CommentId = commentId, PostId = postId, Text = "Comment 1" };

        _context.Comments.Add(comment);
        _context.SaveChanges();

        var commentService = new CommentService(_context);

        commentService.DeleteComment(commentId);

        var deletedcomment = _context.Comments.Find(commentId);
        Assert.Null(deletedcomment);
    }

    [Fact]
    public void DeleteComment_ThrowsNotFoundException()
    {
        var commentId = 1;

        var commentService = new CommentService(_context);

        var exception = Assert.Throws<NotFoundException>(() => commentService.DeleteComment(commentId));
        Assert.Equal("Comment not found.", exception.Message);
    }

}