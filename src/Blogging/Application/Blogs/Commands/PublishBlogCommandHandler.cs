namespace Blogging.Application.Blogs.Commands;

internal class PublishBlogCommandHandler(
    IEntityRepository<Blog> _repository
    ) : ICommandHandler<PublishBlogCommand, Result>
{
    public async Task<Result> Handle(PublishBlogCommand command, CancellationToken cancellationToken)
    {
        var blog = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (blog == null) return Result.NotFound();

        blog.GoOnline();

        await _repository.UpdateAsync(blog, cancellationToken);

        return Result.Success();
    }
}
