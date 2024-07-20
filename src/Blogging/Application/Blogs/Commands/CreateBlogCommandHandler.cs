﻿namespace Blogging.Application.Blogs.Commands;

internal class CreateBlogCommandHandler(
    ILogger<CreateBlogCommandHandler> _logger,
    IRepository<Blog> _repository)

    : ICommandHandler<CreateBlogCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateBlogCommand command, CancellationToken cancellationToken)
    {
        var blog = new Blog(command.Name, description: command.Description);

        await _repository.AddAsync(blog, cancellationToken);

        _logger.LogInformation("Blog {BlogId} created. {Blog}", blog.Id, blog);

        return Result.Success(blog.Id);
    }
}
