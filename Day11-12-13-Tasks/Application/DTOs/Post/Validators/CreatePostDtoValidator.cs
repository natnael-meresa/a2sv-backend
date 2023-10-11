using FluentValidation;

namespace Application.DTOs.Post.Validators
{
    public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
    {
        public CreatePostDtoValidator()
        {
            RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Content)
            .NotEmpty().WithMessage("{PropertyName} is required");

        }
    }
    
}