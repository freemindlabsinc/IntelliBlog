namespace Blogging.Application.UseCases.Blogs.Unpublish;

public class UnpublishBlogCommandValidator : AbstractValidator<UnpublishBlogCommand>
{
    public UnpublishBlogCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
