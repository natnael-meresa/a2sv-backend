public class CommentService
{
    private readonly BloggingContext _context;

    public CommentService(BloggingContext context)
    {
        _context = context;
    }

    public List<Comment> GetCommentsByPostId(int postId)
    {
        var comments = _context.Comments.Where(c => c.PostId == postId).ToList();
        return comments;
    }

    public void CreateComment(Comment comment)
    {


        try
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            // Handle the exception or log the error
            throw new Exception("Failed to create the comment.", ex);
        }
    }

    public void UpdateComment(Comment comment)
    {

        try
        {
            _context.Comments.Update(comment);
            _context.SaveChanges();

        }
        catch (Exception ex)
        {
            throw new Exception("Failed to update the comment.", ex);
        }
    }

    public void DeleteComment(int commentId)
    {

        var comment = _context.Comments.Find(commentId);
        if (comment == null)
        {
            throw new NotFoundException("Comment not found.");
        }

        try
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to delete the comment.", ex);
        }
    }
}