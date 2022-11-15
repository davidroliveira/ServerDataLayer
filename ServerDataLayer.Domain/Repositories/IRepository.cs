namespace Server.Domain.Repositories;

public interface IRepository : IBaseRepository
{
    Task<IEnumerable<object>> QueryAsync(string command, IDictionary<string, object?>? param = null);
}