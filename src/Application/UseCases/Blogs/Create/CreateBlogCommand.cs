namespace Blogging.Application.UseCases.Blogs.Create;

public readonly record struct CreateBlogCommand(string Name, string? Description = default) 
    : ICommand<Result<BlogId>>;
