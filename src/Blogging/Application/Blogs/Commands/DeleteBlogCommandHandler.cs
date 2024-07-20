namespace Blogging.Application.Blogs.Commands;

internal class DeleteBlogCommandHandler(
    IRepository<Blog> _repository)
    : ICommandHandler<DeleteBlogCommand, Result>
{
    public async Task<Result> Handle(DeleteBlogCommand command, CancellationToken cancellationToken)
    {
        var blog = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (blog == null) return Result.NotFound();

        await _repository.DeleteAsync(blog, cancellationToken);

        return Result.Success();
    }
}


