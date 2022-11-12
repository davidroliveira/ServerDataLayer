using ServerDataLayer.Application.Contracts;

namespace ServerDataLayer.Application.UseCases;

public sealed record QueryResponse(IEnumerable<object> Content) : IResponse;