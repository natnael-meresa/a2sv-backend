using Application.DTOs.Post;
using MediatR;

namespace Application.Features.Posts.Requests.Commands
{
 public class GetPostRequestDetailsRequest : IRequest<PostDto>
 {
        public int Id { get; set; }
 }   
}