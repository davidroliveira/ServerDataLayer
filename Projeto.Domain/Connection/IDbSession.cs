using System.Data;

namespace Projeto.Domain.Connection;

public interface IDbSession : IDisposable
{
    IDbConnection Connection { get; }
}