namespace ServerDataLayer.Domain.Connection;

public interface IDbChangeset : IDisposable
{
    void Apply();
}