namespace Blogging.Application.Blogs.Commands;

internal class UnpublishBlogCommandHandler(
    IRepository<Blog> _repository)
    : ICommandHandler<UnpublishBlogCommand, Result>
{
    public async Task<Result> Handle(UnpublishBlogCommand command, CancellationToken cancellationToken)
    {
        var blog = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (blog == null) return Result.NotFound();

        blog.GoOffline();

        await _repository.UpdateAsync(blog, cancellationToken);

        return Result.Success();
    }
}

