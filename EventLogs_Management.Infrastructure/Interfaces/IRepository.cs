using EventLogs_Management.Core;

namespace EventLogs_Management.Infrastructure.Interfaces;

public interface IRepository<T> : IDisposable
    where T : EntityBase
{        
    Task<IEnumerable<T>> List();
    Task<IEnumerable<T>> Filter(Func<T, bool> predicate);
    Task<T> Save(T entity);
}
