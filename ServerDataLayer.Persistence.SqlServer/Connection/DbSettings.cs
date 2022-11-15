using Microsoft.Extensions.Configuration;
using Server.Domain.Connection;

namespace Server.Persistence.SqlServer.Connection;

public sealed class DbSettings : IDbSettings
{
    private readonly IConfiguration _configuration;
    public string ConnectionString => _configuration.GetConnectionString("DefaultConnection")!;

    public DbSettings(IConfiguration configuration) => _configuration = configuration;
}