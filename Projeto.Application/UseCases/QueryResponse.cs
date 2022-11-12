using Projeto.Application.Contracts;

namespace Projeto.Application.UseCases;

public sealed record QueryResponse(IEnumerable<object> Content) : IResponse;