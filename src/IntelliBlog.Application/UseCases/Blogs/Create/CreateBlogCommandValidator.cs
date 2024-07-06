using FluentValidation;

namespace IntelliBlog.Application.UseCases.Blogs.Create;

public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
{
    public CreateBlogCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty();
        
    }
}
