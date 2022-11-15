namespace Server.Domain.Connection;

public interface IDbSettings
{
    string ConnectionString { get; }
}