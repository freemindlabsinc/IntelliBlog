namespace Blogging.Application.Blogs.Commands;

public readonly record struct UnpublishBlogCommand(int Id)
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

