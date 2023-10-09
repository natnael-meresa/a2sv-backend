using Application.DTOs.Post;
using MediatR;

namespace Application.Features.Posts.Requests.Commands
{
 public class UpdatePostRequestCommand : IRequest
 {
  public  UpdatePostDto UpdatePostDto {get; set;} = null!;
 }   
}