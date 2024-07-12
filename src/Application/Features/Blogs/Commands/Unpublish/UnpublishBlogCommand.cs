namespace Application.Features.Blogs.Commands.Unpublish;

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

