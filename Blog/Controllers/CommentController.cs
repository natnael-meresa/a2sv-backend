using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("api/posts/{postId}/comments")]
public class CommentController : ControllerBase
{
    private readonly CommentService _commentService;

    public CommentController(CommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    public ActionResult<List<Comment>> GetCommentsByPostId(int postId)
    {
        var comments = _commentService.GetCommentsByPostId(postId);
        return Ok(comments);
    }

    [HttpPost]
    public ActionResult<Comment> CreateComment(int postId, Comment comment)
    {
        try
        {
            comment.PostId = postId;
            _commentService.CreateComment(comment);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);

        }

        return CreatedAtAction("GetCommentById", new { postId, id = comment.CommentId }, comment);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateComment(int postId, int id, Comment comment)
    {

        try
        {
            _commentService.UpdateComment(comment);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);

        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteComment(int postId, int id)
    {
        try
        {
            _commentService.DeleteComment(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);

        }
        return NoContent();
    }
}