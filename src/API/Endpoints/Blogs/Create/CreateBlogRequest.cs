namespace API.Endpoints.Blogs.Create;

/// <summary>
/// Creates a new blog.
/// </summary>
/// <param name="Name">The name of the blog.</param>
/// <param name="Description">A description (optional).</param>
public readonly record struct CreateBlogRequest(
    string Name,
    string? Description) : IRequest<CreateBlogResponse>
{
    internal class CreateBlogRequestValidator : AbstractValidator<CreateBlogRequest>
    {
        public CreateBlogRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
