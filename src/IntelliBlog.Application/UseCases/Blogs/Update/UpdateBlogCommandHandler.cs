using Blogging.Domain.Aggregates.Blogs;
using Blogging.Domain.Services;

namespace Blogging.Application.UseCases.Blogs.Update;

public class UpdateBlogCommandHandler(IUnitOfWork _unitOfWork)
    : ICommandHandler<UpdateBlogCommand, Result>
{
    public async Task<Result> Handle(UpdateBlogCommand command, CancellationToken cancellationToken)
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

        return Result.Success();
    }
}
