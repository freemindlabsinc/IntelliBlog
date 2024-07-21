namespace Blogging.Application.Posts.Commands;

public record DeletePostCommand(int Id) : ICommand<Result>;

public class DeletePostCommandHandler(IRepository<Post> _repository) : ICommandHandler<DeletePostCommand, Result>
{
    public async Task<Result> Handle(DeletePostCommand command, CancellationToken cancellationToken)
    {
        var Post = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (Post == null)
        {
            return Result.NotFound("Post not found");
        }

        await _repository.DeleteAsync(Post);

        return Result.Success();
    }
}

public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
{
    public DeletePostCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}

