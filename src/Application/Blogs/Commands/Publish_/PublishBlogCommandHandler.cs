using Blogging.Domain.Aggregates.Blogs;

namespace Application.Blogs.Commands.Publish_;

internal class PublishBlogCommandHandler(IRepository<Blog> _repository) : ICommandHandler<PublishBlogCommand, Result>
{
    public async Task<Result> Handle(PublishBlogCommand command, CancellationToken cancellationToken)
    {
        var spec = new BlogByIdSpec(command.Id);
        var blog = await _repository.SingleOrDefaultAsync(spec, cancellationToken);

        if (blog == null)
        {
            return Result.NotFound();
        }

        blog.Publish();

        return Result.Success();

    }
}
