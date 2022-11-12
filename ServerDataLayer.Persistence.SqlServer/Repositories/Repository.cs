using Dapper;
using ServerDataLayer.Domain.Connection;
using ServerDataLayer.Domain.Repositories;

namespace ServerDataLayer.Persistence.SqlServer.Repositories;

public sealed class Repository : BaseRepository, IRepository
{
    private readonly IDbSession _session;

    public Repository(IDbSession session) => _session = session;

    public IEnumerable<object> Query(string command, IDictionary<string, object?>? param = null)
    {
        //var teste = new Dictionary<string, object?>
        //{
        //    {"@codigo_local", 1}
        //};

        //var teste = new Dictionary<string, object?>();
        //teste.Clear();
        //param?.Keys.ToList().ForEach(key => teste.TryAdd(key, JsonConvert.DeserializeObject(param[key]?.ToString() ?? null)));
        //return _session.Connection.Query<object>(command, teste);
        return _session.Connection.Query<object>(command, param);
    }
}