using ServerDataLayer.Application.Contracts;
using ServerDataLayer.Domain.Repositories;

namespace ServerDataLayer.Application.UseCases;

public sealed class QueryUseCase : IUseCase<QueryRequest, QueryResponse>
{
    private readonly IRepository _repository;

    public QueryUseCase(IRepository repository) => _repository = repository;

    public QueryResponse Execute(QueryRequest request)
    {
        //var teste = request.Param?.Keys.ToList().ForEach(key => teste.TryAdd(key, JsonConvert.DeserializeObject(param[key]?.ToString() ?? null)));
        //request.Param?.Keys.ToList().ForEach(key => request.Param[key] = JsonConvert.DeserializeObject(request.Param[key].ToString() ?? null));
        //return new(_repository.Query(request.Command, request.Param));
        //request.Param?.Keys.ToList().ForEach(key => request.Param[key] = JsonConvert.DeserializeObject(request.Param[key].ToString() ?? null));
        
        //var paramsQuery = request.Query
        //    .QueryParameters?
        //    .ToDictionary(model => model.Name, model => model.Value);
        
        return new(_repository.Query(request.Query.Command, request.Query.ToDictionary()));
    }
}