namespace Blogging.Application.Blogs.Commands;

public record UnpublishBlogCommand(int Id)
    : ICommand<Result>
{
    internal class UnpublishBlogCommandValidator : AbstractValidator<UnpublishBlogCommand>
    {
        public UnpublishBlogCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}

