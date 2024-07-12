using Application.Features.Blogs.Commands.Create;

namespace API.Endpoints.Blogs.Create;

/// <summary>
/// The handler for <see cref="CreateBlogRequest"/>.
/// </summary>
/// <param name="_sender"></param>
internal class CreateBlogEndpoint(ISender _sender) : RequestEndpoint<CreateBlogRequest, CreateBlogResponse>
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
            Response = new CreateBlogResponse(result.Value);
            return;
        }

        // TODO Handle errors
    }
}
