using Server.Application.Contracts;
using Server.Domain.Repositories;

namespace Server.Application.UseCases;

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