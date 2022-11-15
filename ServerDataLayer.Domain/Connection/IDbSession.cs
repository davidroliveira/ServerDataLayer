using System.Data;

namespace Server.Domain.Connection;

public interface IDbSession : IDisposable
{
    IDbConnection Connection { get; }
}