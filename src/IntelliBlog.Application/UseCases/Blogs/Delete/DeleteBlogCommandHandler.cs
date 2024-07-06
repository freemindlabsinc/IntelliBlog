using IntelliBlog.Application.Interfaces;

namespace IntelliBlog.Application.UseCases.Blogs.Delete;

public class DeleteBlogCommandHandler(
    IMediator _mediator,
    IUnitOfWork _unitOfWork)
    : ICommandHandler<DeleteBlogCommand, Result>
{
    public async Task<Result> Handle(DeleteBlogCommand command, CancellationToken cancellationToken)
    {
        var blog = await _unitOfWork.BlogRepository.GetByIdAsync(command.Id, cancellationToken);

        if (blog == null)
        {
            return Result.NotFound("Blog not found");
        }

        await _unitOfWork.BlogRepository.DeleteAsync(blog, cancellationToken);

        await _unitOfWork.CompleteAsync(cancellationToken);

        await _mediator.Publish(new BlogDeletedEvent(blog.Id));

        return Result.Success();
    }
}
