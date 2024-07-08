using Blogging.Domain.Aggregates.Blogs;
using Blogging.Domain.Services;

namespace Blogging.Application.UseCases.Blogs.UpdateImages;

public class UpdateBlogImagesCommandHandler(IUnitOfWork _unitOfWork)
    : ICommandHandler<UpdateBlogImagesCommand, Result>
{
    public async Task<Result> Handle(UpdateBlogImagesCommand request, CancellationToken cancellationToken)
    {
        var blogRepo = _unitOfWork.GetRepository<Blog>();
        var blog = await blogRepo.GetByIdAsync(request.Id, cancellationToken);
        if (blog == null)
        {
            return Result.NotFound("Blog not found");
        }

        blog.UpdateImage(request.Image);
        blog.UpdateSmallImage(request.SmallImage);

        await _unitOfWork.CompleteAsync(cancellationToken);

        return Result.Success();
    }
}
