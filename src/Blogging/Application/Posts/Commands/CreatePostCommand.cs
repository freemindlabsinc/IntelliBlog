namespace Blogging.Application.Posts.Commands;
public record CreatePostCommand(
    int BlogId,
    string Title,
    string? Description = default,
    string? Text = default,
    string[]? Tags = default) : ICommand<Result<int>>
{
    internal class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(x => x.BlogId).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
    }

}

