using Blogging.Domain.Aggregates.Blogs;

namespace Application.UseCases.Blogs.UpdateImages;

public readonly record struct UpdateBlogImagesCommand(BlogId Id, string Image, string SmallImage)
    : ICommand<Result>;


internal class UpdateBlogImagesCommandHandler(IRepository<Blog> _repository)
    : ICommandHandler<UpdateBlogImagesCommand, Result>
{
    public async Task<Result> Handle(UpdateBlogImagesCommand command, CancellationToken cancellationToken)
    {
        var spec = new BlogByIdSpec(command.Id);
        var blog = await _repository.SingleOrDefaultAsync(spec, cancellationToken);
        if (blog == null)
        {
            return Result.NotFound();
        }

        blog.UpdateImage(command.Image);
        blog.UpdateSmallImage(command.SmallImage);

        return Result.Success();
    }
}

internal class UpdateBlogImagesValidator : AbstractValidator<UpdateBlogImagesCommand>
{
    public UpdateBlogImagesValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        // TODO: Iffy. We need to make a value object
        RuleFor(x => x.Image).NotEmpty();
        RuleFor(x => x.SmallImage).NotEmpty();
    }
}
