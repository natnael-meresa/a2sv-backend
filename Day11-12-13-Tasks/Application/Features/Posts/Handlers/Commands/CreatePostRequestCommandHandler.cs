using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Post.Validators;
using Application.Exceptions;
using Application.Features.Posts.Requests.Commands;
using Application.Persistance.Contracts;
using Application.Responses;
using AutoMapper;
using Domain;

// using Domain;
using MediatR;

namespace Application.Features.Posts.Handler.Commands
{
    public class CreatePostRequestCommandHandler : IRequestHandler<CreatePostRequestCommand, BaseCommandResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public CreatePostRequestCommandHandler(IPostRepository postRepository, IMapper imapper)
        {
            _postRepository = postRepository;
            _mapper = imapper;
        }

        public async Task<BaseCommandResponse> Handle(CreatePostRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreatePostDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreatePostDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

                return response;
            }

            var post = _mapper.Map<Post>(request.CreatePostDto);
            await _postRepository.AddAsync(post);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = post.PostId;
            return response;
        }
    }
}