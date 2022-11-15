namespace Server.Domain.Connection;

public interface IDbChangeset : IDisposable
{
    void Apply();
}