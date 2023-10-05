using Application.Persistance.Repositories;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    private readonly PostRepository _postRepository;

    public PostController(PostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    [HttpGet]
    public async  Task<ActionResult> GetAllPosts()
    {
        var posts = await _postRepository.GetAllAsync();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(int id)
    {


        var post = await _postRepository.GetAsync(id);
        return Ok(post);

    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(Post post)
    {
        await _postRepository.AddAsync(post);


        return CreatedAtAction(nameof(GetPostById), new { id = post.PostId }, post);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePost(int id, Post post)
    {
        if (id != post.PostId)
        {
            return BadRequest();
        }
       
        await _postRepository.UpdateAsync(post);
      
       
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        await _postRepository.DeleteAsync(id);
        
        return NoContent();
    }
}