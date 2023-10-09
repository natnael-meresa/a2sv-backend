using MediatR;

namespace Application.Features.Posts.Requests.Commands
{
 public class DeletePostRequestCommand : IRequest
 {
  public int Id { get; set; }  
 }   
}