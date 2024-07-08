using Blogging.Application.UseCases.Sources.Create;
using FastEndpoints;

namespace API.Endpoints.Sources.Create;

public class Create(ISender _sender)
    : Endpoint<CreateSourceRequest, CreateSourceResponse>
{
    public override void Configure()
    {
        Post("/Sources");//CreateArticleRequest.Route);
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
