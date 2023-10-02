using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    private readonly PostService _postService;

    public PostController(PostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public ActionResult<List<Post>> GetAllPosts()
    {
        var posts = _postService.GetAllPosts();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public ActionResult<Post> GetPostById(int id)
    {

        try
        {
            var post = _postService.GetPostById(id);
            return Ok(post);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            // Log the exception or handle the error appropriately
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public ActionResult<Post> CreatePost(Post post)
    {
        try
        {
            _postService.CreatePost(post);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return CreatedAtAction(nameof(GetPostById), new { id = post.PostId }, post);
    }

    [HttpPut("{id}")]
    public ActionResult UpdatePost(int id, Post post)
    {
        if (id != post.PostId)
        {
            return BadRequest();
        }

        try
        {
            _postService.UpdatePost(post);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeletePost(int id)
    {
        try
        {
            _postService.DeletePost(id);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return NoContent();
    }
}