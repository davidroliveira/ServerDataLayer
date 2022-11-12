using System.Data;

namespace ServerDataLayer.Domain.Connection;

public interface IDbSession : IDisposable
{
    IDbConnection Connection { get; }
}