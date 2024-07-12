using Blogging.Domain.Aggregates.Blogs;

namespace Application.UseCases.Blogs.Commands.Publish_;

public readonly record struct PublishBlogCommand(int Id)
    : ICommand<Result>;


internal class PublishBlogCommandHandler(IRepository<Blog> _repository) : ICommandHandler<PublishBlogCommand, Result>
{
    public async Task<Result> Handle(PublishBlogCommand command, CancellationToken cancellationToken)
    {
        var spec = new BlogByIdSpec(command.Id);
        var blog = await _repository.SingleOrDefaultAsync(spec, cancellationToken);

        if (blog == null)
        {
            return Result.NotFound();
        }

        blog.Publish();

        return Result.Success();

    }
}

internal class PublishBlogCommandValidator : AbstractValidator<PublishBlogCommand>
{
    public PublishBlogCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
