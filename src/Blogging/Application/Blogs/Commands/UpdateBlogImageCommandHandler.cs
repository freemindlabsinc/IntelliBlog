namespace Blogging.Application.Blogs.Commands;

internal class UpdateBlogImageCommandHandler(
    IEntityRepository<Blog> _repository
    )
    : ICommandHandler<UpdateBlogImageCommand, Result>
{
    public async Task<Result> Handle(UpdateBlogImageCommand command, CancellationToken cancellationToken)
    {
        var blogResult = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (blogResult == null) return Result.NotFound();

        blogResult.UpdateImage(command.Image);

        return Result.Success();
    }
}
