using Blogging.Domain.Aggregates.Blogs;

namespace Application.UseCases.Blogs.Unpublish;

public readonly record struct UnpublishBlogCommand(int Id)
    : ICommand<Result>;


internal class UnpublishBlogCommandHandler(IRepository<Blog> _repository)
    : ICommandHandler<UnpublishBlogCommand, Result>
{
    public async Task<Result> Handle(UnpublishBlogCommand command, CancellationToken cancellationToken)
    {
        var spec = new BlogByIdSpec(command.Id);
        var blog = await _repository.SingleOrDefaultAsync(spec, cancellationToken);

        if (blog == null)
        {
            return Result.NotFound();
        }

        blog.Unpublish();
        await _repository.UpdateAsync(blog, cancellationToken);

        return Result.Success();
    }
}

internal class UnpublishBlogCommandValidator : AbstractValidator<UnpublishBlogCommand>
{
    public UnpublishBlogCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
