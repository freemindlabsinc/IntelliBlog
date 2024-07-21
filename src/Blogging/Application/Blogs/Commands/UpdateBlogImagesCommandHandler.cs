namespace Blogging.Application.Blogs.Commands;

internal class UpdateBlogImagesCommandHandler(
    IEntityRepository<Blog> _repository
    )
    : ICommandHandler<UpdateBlogImageCommand, Result>
{
    public async Task<Result> Handle(UpdateBlogImageCommand command, CancellationToken cancellationToken)
    {
        var blogResult = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (blogResult == null) return Result.NotFound();

        blogResult.Value.UpdateImage(command.Image);

        return Result.Success();
    }
}
