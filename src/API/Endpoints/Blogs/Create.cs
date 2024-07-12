using Application.UseCases.Blogs.Create;

namespace API.Endpoints.Blogs;

/// <summary>
/// Creates a new blog.
/// </summary>
/// <param name="Name">The name of the blog.</param>
/// <param name="Description">A description (optional).</param>
public readonly record struct CreateBlogRequest(
    string Name, 
    string? Description);

/// <summary>
/// The response to <see cref="CreateBlogRequest"/>.
/// </summary>
/// <param name="BlogId">The id of the created blog.</param>
public readonly record struct CreateBlogResponse(
    int BlogId);

/// <summary>
/// The handler for <see cref="CreateBlogRequest"/>.
/// </summary>
/// <param name="_sender"></param>
internal class Create(
    ISender _sender) 
    
    : Endpoint<CreateBlogRequest, CreateBlogResponse>
{
    public override void Configure()
    {
        Post("/Blogs");
        Description(x => x.WithName("CreateBlog"));
        AllowAnonymous();
        Summary(s =>
        {
            // set the example request
            s.ExampleRequest = new CreateBlogRequest("Blog Title", "Blog Description");
        });
    }

    public override async Task HandleAsync(
        CreateBlogRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateBlogCommand>();

        var result = await _sender.Send(command);

        if (result.IsSuccess)
        {
            Response = new CreateBlogResponse(result.Value.Value);
            return;
        }

        // TODO Handle errors
    }
}

internal class CreateBlogRequestValidator : AbstractValidator<CreateBlogRequest>
{
    public CreateBlogRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
