namespace Projeto.Domain.Connection;

public interface IDbChangeset : IDisposable
{
    void Apply();
}