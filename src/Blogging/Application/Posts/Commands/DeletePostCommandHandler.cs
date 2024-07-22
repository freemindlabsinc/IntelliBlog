namespace Blogging.Application.Posts.Commands;

public class DeletePostCommandHandler(
    IEntityRepository<Post> _repository) 
    : ICommandHandler<DeletePostCommand, Result>
{
    public async Task<Result> Handle(DeletePostCommand command, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (result == null)
        {
            return Result.NotFound("Post not found");
        }

        await _repository.DeleteAsync(result.Id);

        return Result.Success();
    }
}
