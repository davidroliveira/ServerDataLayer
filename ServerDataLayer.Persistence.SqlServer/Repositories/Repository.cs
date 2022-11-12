using Dapper;
using ServerDataLayer.Domain.Connection;
using ServerDataLayer.Domain.Repositories;

namespace ServerDataLayer.Persistence.SqlServer.Repositories;

public sealed class Repository : BaseRepository, IRepository
{
    private readonly IDbSession _session;

    public Repository(IDbSession session) => _session = session;

    public Task<IEnumerable<object>> QueryAsync(string command, IDictionary<string, object?>? param = null) => _session
        .Connection
        .QueryAsync<object>(
            command, 
            param);
}