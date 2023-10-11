using Application.DTOs.Post;
using Application.Responses;
using MediatR;

namespace Application.Features.Posts.Requests.Commands
{
 public class CreatePostRequestCommand : IRequest<BaseCommandResponse>
 {
     public CreatePostDto CreatePostDto { get; set; } = null!;
 }   
}