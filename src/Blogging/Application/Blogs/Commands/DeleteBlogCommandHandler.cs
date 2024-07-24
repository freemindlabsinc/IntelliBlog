namespace Blogging.Application.Blogs.Commands;

internal class DeleteBlogCommandHandler(
    IEntityRepository<Blog> _repository)
    : ICommandHandler<DeleteBlogCommand, Result>
{
    public async Task<Result> Handle(DeleteBlogCommand command, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (result == null) return Result.NotFound();

        await _repository.DeleteAsync(result.Id, cancellationToken);

        return Result.Success();
    }
}


