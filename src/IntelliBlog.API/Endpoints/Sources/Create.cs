using FastEndpoints;
using IntelliBlog.API.Application.UseCases.Sources.Create;

namespace IntelliBlog.API.Endpoints.Sources;

public class Create(IMediator _mediator) 
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
        var result = await _mediator.Send(new CreateSourceCommand(
            request.Name, request.Url, request.Description, request.Tags), cancellationToken);
        
        if (result.IsSuccess)
        {
            Response = new CreateSourceResponse(result.Value);
            return;
        }
    }
}
