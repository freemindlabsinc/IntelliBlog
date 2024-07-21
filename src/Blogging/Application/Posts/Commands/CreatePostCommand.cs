namespace Blogging.Application.Posts.Commands;
public record CreatePostCommand(
    int BlogId,
    string Title,
    string? Description = default,
    string? Text = default,
    string[]? Tags = default) : ICommand<Result<int>>;

internal class CreatePostCommandHandler(IRepository<Post> _repository) :
    ICommandHandler<CreatePostCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreatePostCommand command, CancellationToken cancellationToken)
    {
        var Post = new Post(command.BlogId, command.Title, command.Description);

        Post.UpdateText(command.Text);

        if (command.Tags != null)
        {
            Post.AddTags(command.Tags);
        }

        await _repository.AddAsync(Post, cancellationToken);

        return Result.Success(Post.Id);
    }
}

internal class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(x => x.BlogId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
    }
}
