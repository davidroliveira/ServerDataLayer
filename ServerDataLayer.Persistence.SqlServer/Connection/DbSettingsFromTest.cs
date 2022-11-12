using Microsoft.Extensions.Configuration;
using ServerDataLayer.Domain.Connection;
using System.Data.SqlClient;

namespace ServerDataLayer.Persistence.SqlServer.Connection;

public sealed class DbSettingsFromTest : IDbSettings
{
    public string ConnectionString { get; }

    public DbSettingsFromTest(IConfiguration configuration)
    {
        var connectionStringBuilder = new SqlConnectionStringBuilder(new DbSettings(configuration).ConnectionString);
        connectionStringBuilder.InitialCatalog += "-Test";
        ConnectionString = connectionStringBuilder.ToString();
    }
}