﻿using Blogging.Domain.Aggregates.Blogs;
using Blogging.Domain.Specifications;

namespace Blogging.Application.UseCases.Blogs.Delete;

public class DeleteBlogCommandHandler(
    IRepository<Blog> _repository)
    : ICommandHandler<DeleteBlogCommand, Result>
{
    public async Task<Result> Handle(DeleteBlogCommand command, CancellationToken cancellationToken)
    {
        var spec = new BlogByIdSpec(command.Id);
        var blog = await _repository.SingleOrDefaultAsync(spec, cancellationToken);

        if (blog == null)
        {
            return Result.NotFound();
        }
    
        blog.MarkDeleted(); // TODO implement marking in repository
        await _repository.DeleteAsync(blog, cancellationToken);

        return Result.Success();
    }
}
