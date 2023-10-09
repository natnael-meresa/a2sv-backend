using Application.DTOs.Post;
using MediatR;

namespace Application.Features.Posts.Requests.Commands
{
 public class CreatePostRequestCommand : IRequest<int>
 {
     public CreatePostDto CreatePostDto { get; set; } = null!;
 }   
}