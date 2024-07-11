namespace Blogging.Application.UseCases.Blogs.Create;

/// <summary>
/// 
/// </summary>
/// <param name="Name"></param>
/// <param name="Description"></param>
public readonly record struct CreateBlogCommand(string Name, string? Description = default) 
    : ICommand<Result<BlogId>>;
