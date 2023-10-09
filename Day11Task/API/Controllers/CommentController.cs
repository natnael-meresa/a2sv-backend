using Application.Persistance.Repositories;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("api/comments")]
public class CommentController : ControllerBase
{
    private readonly CommentRepository _commentRepository;

    public CommentController(CommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
   

    [HttpPost]
    public async Task<IActionResult> CreateComment(int postId, Comment comment)
    {

        comment.PostId = postId;
        await _commentRepository.AddAsync(comment);

        return CreatedAtAction("GetCommentById", new { postId, id = comment.CommentId }, comment);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateComment(Comment comment)
    {
        await _commentRepository.UpdateAsync(comment);
       
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        await _commentRepository.DeleteAsync(id);
        
        return NoContent();
    }
}