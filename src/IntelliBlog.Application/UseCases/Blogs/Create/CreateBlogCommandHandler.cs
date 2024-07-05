using IntelliBlog.Application.Interfaces;
using IntelliBlog.Domain.Aggregates.Blogs;

namespace IntelliBlog.Application.UseCases.Blogs.Create;

public class CreateBlogCommandHandler(
    IMediator _mediator,
    IUnitOfWork _unitOfWork)
    : ICommandHandler<CreateBlogCommand, Result<BlogId>>
{
    public async Task<Result<BlogId>> Handle(CreateBlogCommand command, CancellationToken cancellationToken)
    {
        var blog = Blog.CreateNew(command.Name, description: command.Description);

        await _unitOfWork.BlogRepository.AddAsync(blog, cancellationToken);

        await _unitOfWork.CompleteAsync(cancellationToken);

        await _mediator.Publish(new BlogCreatedEvent(blog.Id), cancellationToken);

        return Result.Success(blog.Id);
    }
}
