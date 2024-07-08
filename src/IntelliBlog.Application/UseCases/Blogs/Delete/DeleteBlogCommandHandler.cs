using Blogging.Application.Interfaces;
using Blogging.Domain.Aggregates.Blogs;

namespace Blogging.Application.UseCases.Blogs.Delete;

public class DeleteBlogCommandHandler(
    IRepository<Blog> _repository)
    : ICommandHandler<DeleteBlogCommand, Result>
{
    public async Task<Result> Handle(DeleteBlogCommand command, CancellationToken cancellationToken)
    {
        var blog = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (blog == null)
        {
            return Result.NotFound("Blog not found");
        }
    
        blog.MarkDeleted(); // TODO implement marking in repository
        await _repository.DeleteAsync(blog, cancellationToken);

        return Result.Success();
    }
}
