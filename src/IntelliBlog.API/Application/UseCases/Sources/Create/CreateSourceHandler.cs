namespace IntelliBlog.API.Application.UseCases.Sources.Create;

public class CreateSourceHandler : ICommandHandler<CreateSourceCommand, Result<int>>
{
    public Task<Result<int>> Handle(CreateSourceCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
