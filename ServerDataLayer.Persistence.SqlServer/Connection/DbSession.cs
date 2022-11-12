using ServerDataLayer.Domain.Connection;
using System.Data;
using System.Data.SqlClient;

namespace ServerDataLayer.Persistence.SqlServer.Connection;

public sealed class DbSession : IDbSession
{
    public IDbConnection Connection { get; }

    public DbSession(IDbSettings settings)
    {
        Connection = new SqlConnection(settings.ConnectionString);
        Connection.Open();
    }

    public void Dispose() => Connection.Dispose();
}