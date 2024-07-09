namespace Blogging.Application.UseCases.Blogs.Create;

public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
{
    public CreateBlogCommandValidator()
    {
        this.RuleFor(c => c.Name)
            .NotEmpty();
        
    }
}
