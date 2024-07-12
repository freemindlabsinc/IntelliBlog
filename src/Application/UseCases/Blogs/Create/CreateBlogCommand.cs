using Blogging.Domain.Aggregates.Blogs;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Blogs.Create;

/// <summary>
/// 
/// </summary>
/// <param name="Name"></param>
/// <param name="Description"></param>
public readonly record struct CreateBlogCommand(string Name, string? Description = default) 
    : ICommand<Result<BlogId>>;

internal class CreateBlogCommandHandler(
    ILogger<CreateBlogCommandHandler> _logger,
    IRepository<Blog> _repository)
    : ICommandHandler<CreateBlogCommand, Result<BlogId>>
{
    public async Task<Result<BlogId>> Handle(CreateBlogCommand command, CancellationToken cancellationToken)
    {
        var blog = Blog.CreateNew(command.Name, description: command.Description);

        await _repository.AddAsync(blog, cancellationToken);

        _logger.LogInformation("Blog {BlogId} created. {Blog}", blog.Id, blog);

        return Result.Success(blog.Id);
    }
}

internal class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
{
    public CreateBlogCommandValidator()
    {
        this.RuleFor(c => c.Name)
            .NotEmpty();

    }
}
