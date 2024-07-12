using Blogging.Domain.Aggregates.Blogs;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Blogs.Commands.Create;

/// <summary>
/// 
/// </summary>
/// <param name="Name"></param>
/// <param name="Description"></param>
public readonly record struct CreateBlogCommand(string Name, string? Description = default)
    : ICommand<Result<int>>
{
    internal class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty();
        }
    }

    internal class CreateBlogCommandHandler(ILogger<CreateBlogCommandHandler> _logger, IRepository<Blog> _repository)
    : ICommandHandler<CreateBlogCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(CreateBlogCommand command, CancellationToken cancellationToken)
        {
            var blog = Blog.CreateNew(command.Name, description: command.Description);

            await _repository.AddAsync(blog, cancellationToken);

            _logger.LogInformation("Blog {BlogId} created. {Blog}", blog.Id, blog);

            return Result.Success(blog.Id);
        }
    }
}

