namespace Blogging.Application.Blogs.Commands;

internal class CreateBlogCommandHandler(
    //IDomainEventDispatcher _dispatcher,
    IRepository<Blog> _repository)

    : ICommandHandler<CreateBlogCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateBlogCommand command, CancellationToken cancellationToken)
    {
        var blog = new Blog(
            name: command.Name, 
            description: command.Description,
            image: command.Image,
            notes: command.Notes);

        await _repository.AddAsync(blog, cancellationToken);

        return Result.Success(blog.Id);
    }
}
