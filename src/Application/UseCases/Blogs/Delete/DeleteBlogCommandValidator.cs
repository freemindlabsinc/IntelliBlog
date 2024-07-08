namespace Blogging.Application.UseCases.Blogs.Delete;

public class DeleteBlogCommandValidator : AbstractValidator<DeleteBlogCommand>
{
    public DeleteBlogCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
