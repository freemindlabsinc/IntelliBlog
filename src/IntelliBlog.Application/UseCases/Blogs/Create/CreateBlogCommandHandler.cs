using IntelliBlog.Application.Interfaces;
using IntelliBlog.Domain.Aggregates.Blogs;

namespace IntelliBlog.Application.UseCases.Blogs.Create;

public class CreateBlogCommandHandler(
    IRepository<Blog> _repository)
    : ICommandHandler<CreateBlogCommand, Result<BlogId>>
{
    public async Task<Result<BlogId>> Handle(CreateBlogCommand command, CancellationToken cancellationToken)
    {
        var blog = Blog.CreateNew(command.Name, description: command.Description);

        await _repository.AddAsync(blog, cancellationToken);

        return Result.Success(blog.Id);
    }
}
