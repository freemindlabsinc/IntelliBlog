namespace IntelliBlog.Application.UseCases.Blogs.UpdateImages;

public readonly record struct UpdateBlogImagesCommand(BlogId Id, string Image, string SmallImage)
    : ICommand<Result>;
