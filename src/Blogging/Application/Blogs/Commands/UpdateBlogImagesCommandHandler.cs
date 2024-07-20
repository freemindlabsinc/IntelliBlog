namespace Blogging.Application.Blogs.Commands;

internal class UpdateBlogImagesCommandHandler(
    IRepository<Blog> _repository
    )
    : ICommandHandler<UpdateBlogImageCommand, Result>
{
    public async Task<Result> Handle(UpdateBlogImageCommand command, CancellationToken cancellationToken)
    {
        var blog = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (blog == null) return Result.NotFound();

        blog.UpdateImage(command.Image);

        return Result.Success();
    }
}
