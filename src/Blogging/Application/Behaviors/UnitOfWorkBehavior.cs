namespace Blogging.Application.Behaviors;

public class UnitOfWorkBehavior<TRequest, TResponse>(
    IUnitOfWork _unitOfWork,
    ILogger<UnitOfWorkBehavior<TRequest, TResponse>> _logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            Func<Task<object>> act2 = async () =>
            {
                var nextResult = await next();
                return nextResult!;
            };

            _unitOfWork.Setup(act2);
            var nextInUow = (TResponse)await _unitOfWork.CompleteAsync(cancellationToken);
            return nextInUow;
        }
        catch (Exception ex)
        {
            // TODO improve this
            _logger.LogError(ex, "Error handling {CommandName}", typeof(TRequest).Name);
            throw;
        }
    }
}
