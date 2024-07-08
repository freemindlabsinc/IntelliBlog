﻿using Blogging.Domain.Aggregates.Blogs;
using Blogging.Domain.Specifications;

namespace Blogging.Application.UseCases.Blogs.UpdateImages;

public class UpdateBlogImagesCommandHandler(IRepository<Blog> _repository)
    : ICommandHandler<UpdateBlogImagesCommand, Result>
{
    public async Task<Result> Handle(UpdateBlogImagesCommand command, CancellationToken cancellationToken)
    {
        var spec = new BlogByIdSpec(command.Id);
        var blog = await _repository.SingleOrDefaultAsync(spec, cancellationToken);
        if (blog == null)
        {
            return Result.NotFound();
        }

        blog.UpdateImage(command.Image);
        blog.UpdateSmallImage(command.SmallImage);

        return Result.Success();
    }
}
