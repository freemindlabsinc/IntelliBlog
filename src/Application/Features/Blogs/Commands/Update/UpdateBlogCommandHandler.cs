using Blogging.Domain.Aggregates.Blogs;

namespace Application.Features.Blogs.Commands.Update;

internal class UpdateBlogCommandHandler(IRepository<Blog> _repository)
    : ICommandHandler<UpdateBlogCommand, Result>
{
    public async Task<Result> Handle(UpdateBlogCommand command, CancellationToken cancellationToken)
    {
        var spec = new BlogByIdSpec(command.Id);
        var blog = await _repository.SingleOrDefaultAsync(spec, cancellationToken);
        if (blog == null)
        {
            return Result.NotFound();
        }

        blog.UpdateName(command.Name);
        blog.UpdateDescription(command.Description);
        blog.UpdateNotes(command.Notes);

        await _repository.UpdateAsync(blog);

        return Result.Success();
    }
}
