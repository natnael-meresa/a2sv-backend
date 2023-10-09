using System.Collections.Generic;
using Application.DTOs.Post;
using MediatR;

namespace Application.Features.Posts.Requests.Commands
{
 public class GetPostRequestListRequest : IRequest<List<ListPostDto>>
 {
     public ListPostDto ListPostDto { get; set; } = null!;
 }   
}