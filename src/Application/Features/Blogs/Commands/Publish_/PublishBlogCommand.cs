namespace Application.Features.Blogs.Commands.Publish_;

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
