using Microsoft.Extensions.Configuration;
using Projeto.Domain.Connection;
using System.Data.SqlClient;

namespace Projeto.Persistence.SqlServer.Connection;

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