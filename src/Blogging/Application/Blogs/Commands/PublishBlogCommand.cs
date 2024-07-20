namespace Blogging.Application.Blogs.Commands;

public readonly record struct PublishBlogCommand(int Id)
    : ICommand<Result>
{
    internal class PublishBlogCommandValidator : AbstractValidator<PublishBlogCommand>
    {
        public PublishBlogCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
