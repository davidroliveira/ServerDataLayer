namespace ServerDataLayer.Domain.Connection;

public interface IDbSettings
{
    string ConnectionString { get; }
}