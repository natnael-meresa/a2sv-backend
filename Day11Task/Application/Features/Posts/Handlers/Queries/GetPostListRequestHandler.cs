using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Post;
using Application.Features.Posts.Requests.Commands;
using Application.Persistance.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.Posts.Handler.Commands
{
    public class GetPostRequestDetailsRequestHandler : IRequestHandler<GetPostRequestDetailsRequest, PostDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public GetPostRequestDetailsRequestHandler(IPostRepository postRepository, IMapper imapper)
        {
            _postRepository = postRepository;
            _mapper = imapper;
        }

        public async Task<PostDto> Handle(GetPostRequestDetailsRequest request, CancellationToken cancellationToken)
        {
             var post = await _postRepository.GetAsync(request.Id);
            return _mapper.Map<PostDto>(post);
        }
    }
}