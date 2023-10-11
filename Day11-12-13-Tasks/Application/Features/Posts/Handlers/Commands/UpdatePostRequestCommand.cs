using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Post.Validators;
using Application.Exceptions;
using Application.Features.Posts.Requests.Commands;
using Application.Persistance.Contracts;
using AutoMapper;
using Domain;

// using Domain;
using MediatR;

namespace Application.Features.Posts.Handler.Commands
{
    public class UpdatePostRequestCommandHandler : IRequestHandler<UpdatePostRequestCommand>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public UpdatePostRequestCommandHandler(IPostRepository postRepository, IMapper imapper)
        {
            _postRepository = postRepository;
            _mapper = imapper;
        }

        public async Task<Unit> Handle(UpdatePostRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePostDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdatePostDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var post = _mapper.Map<Post>(request.UpdatePostDto);
            await _postRepository.UpdateAsync(post);
            return Unit.Value;
        }
    }
}