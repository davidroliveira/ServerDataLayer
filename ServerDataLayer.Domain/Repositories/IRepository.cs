namespace ServerDataLayer.Domain.Repositories;

public interface IRepository : IBaseRepository
{
    IEnumerable<object> Query(string command, IDictionary<string, object?>? param = null);
}