namespace Blogging.Application.UseCases.Blogs.ChangeStatus;

public class PublishBlogCommandValidator : AbstractValidator<PublishBlogCommand>
{
    public PublishBlogCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
