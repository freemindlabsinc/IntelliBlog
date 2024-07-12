namespace API.Endpoints;

public abstract class RequestEndpoint<TRequest, TResponse> : Endpoint<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{ }
