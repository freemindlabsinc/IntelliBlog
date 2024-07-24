namespace Blogging.Application.Blogs.Commands;

// Partial updates patterns https://chatgpt.com/share/adbc7fac-e8ed-4317-88a2-1b46594cc673

internal class UpdateBlogCommandHandler(
    IEntityRepository<Blog> _repository
    )
    : ICommandHandler<UpdateBlogCommand, Result>
{
    public async Task<Result> Handle(UpdateBlogCommand command, CancellationToken cancellationToken)
    {
        Blog? blog = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (blog == null) return Result.NotFound();

        if (command.Name != null) blog.UpdateName(command.Name);
        if (command.Description != null) blog.UpdateDescription(command.Description);
        if (command.Notes != null) blog.UpdateNotes(command.Notes);

        await _repository.UpdateAsync(blog);

        return Result.Success();
    }
}
