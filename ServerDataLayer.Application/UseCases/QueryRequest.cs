using ServerDataLayer.Application.Contracts;
using ServerDataLayer.Application.ViewModel;

namespace ServerDataLayer.Application.UseCases;

//public sealed record QueryRequest(string Command, IDictionary<string, object?>? Param) : IRequest;
public sealed record QueryRequest(QueryViewModel Query) : IRequest;