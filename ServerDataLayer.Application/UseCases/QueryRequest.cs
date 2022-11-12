using ServerDataLayer.Application.Contracts;
using ServerDataLayer.Application.ViewModel;

namespace ServerDataLayer.Application.UseCases;

public sealed record QueryRequest(QueryViewModel Query) : IRequest;