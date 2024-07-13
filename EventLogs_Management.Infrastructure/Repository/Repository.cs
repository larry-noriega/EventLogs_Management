using EventLogs_Management.Core;
using EventLogs_Management.Core.SQL;
using EventLogs_Management.Infrastructure.Data;
using EventLogs_Management.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using System.Threading;

namespace EventLogs_Management.Infrastructure.Repository;

public class Repository<T> : IRepository<T>, IDisposable
    where T : EntityBase
{
    private readonly EventsLogsDBContext _dbContext;
    private bool disposed = false;

    public Repository(IOptions<SQLSettings> options)
    {
        _dbContext = new EventsLogsDBContext(options);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async Task<IEnumerable<T>> List()
    {           
        return (await _dbContext.Set<T>().ToListAsync())
            .OrderBy(document => document.Id)
            .ToList();
    }

    public async Task<IEnumerable<T>> Filter(Func<T, bool> predicate)
    {
        return await Task.FromResult(_dbContext.Set<T>()
                .Where(predicate)
                .ToList());
    }

    public async Task<T> Save(T entity)
    {
        
        await _dbContext.Set<T>().AddAsync(entity, default);

        _dbContext.SaveChanges();

        return entity;
    }
}
