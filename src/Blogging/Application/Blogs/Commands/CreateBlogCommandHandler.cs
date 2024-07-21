namespace Blogging.Application.Blogs.Commands;

internal class CreateBlogCommandHandler(
    IEntityRepository<Blog> _repository)

    : ICommandHandler<CreateBlogCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateBlogCommand command, CancellationToken cancellationToken)
    {
        // TODO: use Mapster or Automapper
        var blog = new Blog(
            name: command.Name, 
            description: command.Description,
            image: command.Image,
            notes: command.Notes);

        var created = await _repository.CreateAsync(blog, cancellationToken);

        return Result.Success(created.Id);
    }
}
