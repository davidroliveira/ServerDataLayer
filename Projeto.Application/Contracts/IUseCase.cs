namespace Projeto.Application.Contracts;

public interface IUseCase<in TRequest, TResponse>
    where TRequest : IRequest
    where TResponse : IResponse
{
    TResponse Execute(TRequest request);
}