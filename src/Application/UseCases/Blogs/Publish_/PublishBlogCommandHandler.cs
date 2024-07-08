using Blogging.Domain.Aggregates.Blogs;
using Blogging.Domain.Specifications;

namespace Blogging.Application.UseCases.Blogs.ChangeStatus;

public class PublishBlogCommandHandler(IRepository<Blog> _repository) : ICommandHandler<PublishBlogCommand, Result>
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
