using Blogging.Application.UseCases.Sources.Create;

namespace API.Endpoints.Sources;

public readonly record struct CreateSourceRequest(
    int BlogId,
    string Name,
    string? Url,
    string? Description,
    string[]? Tags);

public readonly record struct CreateSourceResponse(int Id);


public class Create(ISender _sender)
    : Endpoint<CreateSourceRequest, CreateSourceResponse>
{
    public override void Configure()
    {
        Post("/Sources");//CreateArticleRequest.Route);        
        Description(x => x.WithName("CreateSource"));
        AllowAnonymous();
        Summary(s =>
        {
            // XML Docs are used by default but are overridden by these properties:
            //s.Summary = "Create a new Article.";
            //s.Description = "Create a new Article. A valid title is required.";
            s.ExampleRequest = new CreateSourceRequest { Name = "Source Name" };
        });
    }

    public override async Task HandleAsync(
      CreateSourceRequest request,
      CancellationToken cancellationToken)
    {
        var command = new CreateSourceCommand(
            request.BlogId,
            request.Name,
            request.Url,
            request.Description,
            request.Tags);

        var result = await _sender.Send(command);

        if (result.IsSuccess)
        {
            Response = new CreateSourceResponse(result.Value.Value);
            return;
        }
    }
}
