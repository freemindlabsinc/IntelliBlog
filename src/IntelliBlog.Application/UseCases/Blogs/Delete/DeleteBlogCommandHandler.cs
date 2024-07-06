using IntelliBlog.Application.Interfaces;
using IntelliBlog.Domain.Aggregates.Blogs;

namespace IntelliBlog.Application.UseCases.Blogs.Delete;

public class DeleteBlogCommandHandler(
    IMediator _mediator,
    IUnitOfWork _unitOfWork)
    : ICommandHandler<DeleteBlogCommand, Result>
{
    public async Task<Result> Handle(DeleteBlogCommand command, CancellationToken cancellationToken)
    {
        var blogRepo = _unitOfWork.GetRepository<Blog>();
        var blog = await blogRepo.GetByIdAsync(command.Id, cancellationToken);

        if (blog == null)
        {
            return Result.NotFound("Blog not found");
        }

        await _unitOfWork.GetRepository<Blog>().DeleteAsync(blog, cancellationToken);

        await _unitOfWork.CompleteAsync(cancellationToken);

        await _mediator.Publish(new BlogDeletedEvent(blog.Id));

        return Result.Success();
    }
}
