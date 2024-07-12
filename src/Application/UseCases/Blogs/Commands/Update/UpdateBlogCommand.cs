using Blogging.Domain.Aggregates.Blogs;

namespace Application.UseCases.Blogs.Commands.Update;

public readonly record struct UpdateBlogCommand(int Id, string Name, string? Description, string? Notes)
    : ICommand<Result>;

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

internal class UpdateBlogCommandValidator : AbstractValidator<UpdateBlogCommand>
{
    public UpdateBlogCommandValidator()
    {
        // TODO review lengths
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(2000);
        RuleFor(x => x.Notes).MaximumLength(2000);
    }
}
