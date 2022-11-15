using Dapper;
using Server.Domain.Connection;
using Server.Domain.Repositories;

namespace Server.Persistence.SqlServer.Repositories;

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