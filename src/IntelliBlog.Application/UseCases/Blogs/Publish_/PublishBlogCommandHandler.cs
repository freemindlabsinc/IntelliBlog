using Blogging.Domain.Aggregates.Blogs;
using Blogging.Domain.Services;

namespace Blogging.Application.UseCases.Blogs.ChangeStatus;

public class PublishBlogCommandHandler(IUnitOfWork _unitOfWork) : ICommandHandler<PublishBlogCommand, Result>
{
    public async Task<Result> Handle(PublishBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = await _unitOfWork.GetRepository<Blog>()
            .GetByIdAsync(request.Id, cancellationToken);
        
        if (blog == null)
        {
            return Result.NotFound("Blog not found");
        }

        blog.Publish();
        
        return Result.Success();

    }
}
