using ServerDataLayer.Application.Contracts;
using ServerDataLayer.Domain.Repositories;

namespace ServerDataLayer.Application.UseCases;

public sealed class QueryUseCase : IUseCase<QueryRequest, QueryResponse>
{
    private readonly IRepository _repository;

    public QueryUseCase(IRepository repository) => _repository = repository;

    public async Task<QueryResponse> ExecuteAsync(QueryRequest request) => new(
        await _repository
            .QueryAsync(
                request.Query.Command, 
                await request.Query.ToDictionaryAsync()));
}