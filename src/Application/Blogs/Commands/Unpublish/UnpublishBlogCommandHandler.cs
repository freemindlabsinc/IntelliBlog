using Blogging.Domain.Aggregates.Blogs;

namespace Application.Blogs.Commands.Unpublish;

internal class UnpublishBlogCommandHandler(IRepository<Blog> _repository)
    : ICommandHandler<UnpublishBlogCommand, Result>
{
    public async Task<Result> Handle(UnpublishBlogCommand command, CancellationToken cancellationToken)
    {
        var spec = new BlogByIdSpec(command.Id);
        var blog = await _repository.SingleOrDefaultAsync(spec, cancellationToken);

        if (blog == null)
        {
            return Result.NotFound();
        }

        blog.Unpublish();
        await _repository.UpdateAsync(blog, cancellationToken);

        return Result.Success();
    }
}

