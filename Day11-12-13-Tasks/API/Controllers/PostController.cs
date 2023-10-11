using Application.DTOs.Post;
using Application.Features.Posts.Requests.Commands;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<PostDto>>> GetAllPosts()
    {
        var posts = await _mediator.Send(new GetPostRequestListRequest());
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostDto>> GetPost(int id)
    {
        var post = await _mediator.Send(new GetPostRequestDetailsRequest() { Id = id });
        return Ok(post);

    }

    [HttpPost]
    public async Task<ActionResult> CreatePost([FromBody] CreatePostDto post)
    {
        var response = await _mediator.Send(new CreatePostRequestCommand() { CreatePostDto = post });


        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePost([FromBody] UpdatePostDto post)
    {
        await _mediator.Send(new UpdatePostRequestCommand() { UpdatePostDto = post });

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost(int id)
    {
        await _mediator.Send(new DeletePostRequestCommand() { Id = id });

        return NoContent();
    }
}