using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Post;
using Application.Features.Posts.Requests.Commands;
using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.Posts.Handler.Commands
{
    public class GetPostRequestListRequestHandler : IRequestHandler<GetPostRequestListRequest, List<ListPostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public GetPostRequestListRequestHandler(IPostRepository postRepository, IMapper imapper)
        {
            _postRepository = postRepository;
            _mapper = imapper;
        }

        public async Task<List<ListPostDto>> Handle(GetPostRequestListRequest request, CancellationToken cancellationToken)
        {
             var posts = await _postRepository.GetAllAsync();
            return _mapper.Map<List<ListPostDto>>(posts);
        }
    }
}