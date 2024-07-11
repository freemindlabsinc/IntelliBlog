using Blogging.Application.UseCases.Blogs.Create;
using FastEndpoints;

namespace API.Endpoints.Blog.Create;

public class Create(ISender _sender) : Endpoint<CreateBlogRequest, CreateBlogResponse>
{
    public override void Configure()
    {
        Post("/Blog");
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
        var command = new CreateBlogCommand(
            Name: request.Name,
            Description: request.Description);

        var result = await _sender.Send(command);

        if (result.IsSuccess)
        {
            Response = new CreateBlogResponse(result.Value.Value);
            return;
        }
        
        // TODO Handle errors
    }
}
