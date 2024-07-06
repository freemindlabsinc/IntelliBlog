using IntelliBlog.Application.Interfaces;
using IntelliBlog.Domain.Aggregates.Blogs;

namespace IntelliBlog.Application.UseCases.Blogs.Update;

public class UpdateBlogCommandHandler(IUnitOfWork _unitOfWork)
    : ICommandHandler<UpdateBlogCommand, Result<int>>
{
    public async Task<Result<int>> Handle(UpdateBlogCommand command, CancellationToken cancellationToken)
    {
        var blogRepo = _unitOfWork.GetRepository<Blog>();
        var blog = await blogRepo.GetByIdAsync(command.Id, cancellationToken);
        if (blog == null)
        {
            return Result.NotFound("Blog not found");
        }

        blog.UpdateName(command.Name);
        blog.UpdateDescription(command.Description);
        blog.UpdateNotes(command.Notes);

        await blogRepo.UpdateAsync(blog);

        var changeCount = await _unitOfWork.CompleteAsync(cancellationToken);

        return Result.Success(changeCount);
    }
}
