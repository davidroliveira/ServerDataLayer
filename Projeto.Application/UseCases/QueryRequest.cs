using Projeto.Application.Contracts;
using Projeto.Application.Dtos;

namespace Projeto.Application.UseCases;

//public sealed record QueryRequest(string Command, IDictionary<string, object?>? Param) : IRequest;
public sealed record QueryRequest(QueryDto Query) : IRequest;