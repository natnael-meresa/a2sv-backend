using System.Threading;
using System.Threading.Tasks;
using Application.Features.Posts.Requests.Commands;
using Application.Persistance.Contracts;
using AutoMapper;
using Domain;

// using Domain;
using MediatR;

namespace Application.Features.Posts.Handler.Commands
{
    public class CreatePostRequestCommandHandler : IRequestHandler<CreatePostRequestCommand, int>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public CreatePostRequestCommandHandler(IPostRepository postRepository, IMapper imapper)
        {
            _postRepository = postRepository;
            _mapper = imapper;
        }

        public async Task<int> Handle(CreatePostRequestCommand request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<Post>(request.CreatePostDto);
            await _postRepository.AddAsync(post);
            return post.PostId;
        }
    }
}