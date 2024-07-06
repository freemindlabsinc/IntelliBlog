using IntelliBlog.Application.Interfaces;
using IntelliBlog.Domain.Aggregates.Blogs;

namespace IntelliBlog.Application.UseCases.Blogs.ChangeStatus;

public class ChangeBlogStatusCommandHandler(IUnitOfWork _unitOfWork) : ICommandHandler<ChangeBlogStatusCommand, Result>
{
    public async Task<Result> Handle(ChangeBlogStatusCommand request, CancellationToken cancellationToken)
    {
        var blog = await _unitOfWork.GetRepository<Blog>()
            .GetByIdAsync(request.Id, cancellationToken);
        
        if (blog == null)
        {
            return Result.NotFound("Blog not found");
        }

        blog.ChangeStatus(request.NewStatus);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return Result.Success();

    }
}
