using FluentValidation;

namespace Application.DTOs.Post.Validators
{
    public class UpdatePostDtoValidator : AbstractValidator<UpdatePostDto>
    {
        public UpdatePostDtoValidator()
        {
            RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Content)
            .NotEmpty().WithMessage("{PropertyName} is required");

        }
    }
    
}