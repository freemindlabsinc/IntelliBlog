namespace IntelliBlog.Application.UseCases.Blogs.Unpublish;

public readonly record struct UnpublishBlogCommand(BlogId Id)
    : ICommand<Result>;
