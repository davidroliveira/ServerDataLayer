using Server.Application.Contracts;
using Server.Application.ViewModel;

namespace Server.Application.UseCases;

public sealed record QueryRequest(QueryViewModel Query) : IRequest;