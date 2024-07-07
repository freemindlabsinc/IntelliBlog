using IntelliBlog.Application.Interfaces;
using IntelliBlog.Domain.Aggregates.Blogs;

namespace IntelliBlog.Application.UseCases.Blogs.Delete;

public class DeleteBlogCommandHandler(
    IPublisher _publisher,
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

        await _repository.DeleteAsync(blog, cancellationToken);

        // Events
        await _publisher.Publish(new BlogDeletedEvent(blog.Id));

        return Result.Success();
    }
}
