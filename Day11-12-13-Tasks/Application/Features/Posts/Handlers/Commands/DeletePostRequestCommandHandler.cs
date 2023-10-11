using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Features.Posts.Requests.Commands;
using Application.Persistance.Contracts;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Posts.Handler.Commands
{
    public class DeletePostRequestCommandHandler : IRequestHandler<DeletePostRequestCommand>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public DeletePostRequestCommandHandler(IPostRepository postRepository, IMapper imapper)
        {
            _postRepository = postRepository;
            _mapper = imapper;
        }

        public async Task<Unit> Handle(DeletePostRequestCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetAsync(request.Id);
            if (post == null)
                throw new NotFoundException(nameof(Post), request.Id);
                
            await _postRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}