using Server.Application.Contracts;

namespace Server.Application.UseCases;

public sealed record QueryResponse(IEnumerable<object> Content) : IResponse;