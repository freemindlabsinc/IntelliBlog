using System.Transactions;
using Blogging.Domain.Services;

namespace Blogging.Application.Behaviors;
public class UnitOfWorkBehavior<TRequest, TResponse>(
    IUnitOfWork _unitOfWork)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        TResponse response;
        using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {            
            response = await next();

            await _unitOfWork.CompleteAsync(cancellationToken);
            
            transactionScope.Complete();
        }

        return response;
    }
}
