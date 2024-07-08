using Blogging.Application.UseCases.Blogs.Create;
using Blogging.Domain.Aggregates;
using FastEndpoints;

namespace API.Endpoints.Blog.Create;

public class Create(ISender _sender) : Endpoint<CreateBlogRequest, CreateBlogResponse>
{
    public override void Configure()
    {
        Post("/Blog");
        AllowAnonymous();
        Summary(s =>
        {
            // set the example request
            s.ExampleRequest = new CreateBlogRequest("Blog Title", "Blog Description");
        });
    }

    // handle the request
    public override async Task HandleAsync(
        CreateBlogRequest request,
        CancellationToken cancellationToken)
    {
        // create a new createblog command
        var command = new CreateBlogCommand(
            Name: request.Name,
            Description: request.Description);

        // send the command
        var result = await _sender.Send(command);

        // if the result is successful
        if (result.IsSuccess)
        {
            // set the response
            Response = new CreateBlogResponse(result.Value.Value);
        }
        // TODO Handle errors
    }
}
