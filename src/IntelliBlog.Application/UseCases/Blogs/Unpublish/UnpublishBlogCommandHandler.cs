using Blogging.Domain.Aggregates.Blogs;

namespace Blogging.Application.UseCases.Blogs.Unpublish;

public class UnpublishBlogCommandHandler(IRepository<Blog> _repository) 
    : ICommandHandler<UnpublishBlogCommand, Result>
{
    public async Task<Result> Handle(UnpublishBlogCommand command, CancellationToken cancellationToken)
    {
        var blog = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (blog is null)
        {
            return Result.NotFound("Blog not found");
        }

        blog.Unpublish();
        await _repository.UpdateAsync(blog, cancellationToken);

        return Result.Success();
    }
}
