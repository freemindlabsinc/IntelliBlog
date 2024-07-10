using Blogging.Application.Interfaces;
using Blogging.Domain.Aggregates.Blogs;
using Microsoft.Extensions.Logging;

namespace Blogging.Application.UseCases.Blogs.Create;

public class CreateBlogCommandHandler(
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
