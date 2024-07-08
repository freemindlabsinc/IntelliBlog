namespace Blogging.Application.UseCases.Blogs.ChangeStatus;

public readonly record struct PublishBlogCommand(BlogId Id)
    : ICommand<Result>;
