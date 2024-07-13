using EventLogs_Management.Core.Models;
using EventLogs_Management.Core.SQL;
using EventLogs_Management.Infrastructure.Interfaces;
using EventLogs_Management.Infrastructure.Repository;
using Microsoft.Extensions.Options;

namespace EventLogs_Management.Domain;

public class EventLogsDomain : IEventLogsDomain
{
    private readonly IRepository<EventLog>? _repository;
    private readonly IOptions<SQLSettings> _options;

    public EventLogsDomain(IOptions<SQLSettings> options)
    {
        _options = options;
        _repository = new Repository<EventLog>(_options);
    }

    public async Task<IEnumerable<EventLog>> GetLogList()
    {
        return await _repository!.List();
    }

    public async Task<IEnumerable<EventLog>> SaveEvent(EventFilter input)
    {
        IEnumerable<EventLog> result = await _repository!.Filter(e => e.EventType == input.EventType);

        return result
                .OrderByDescending(e => e.Date);
    }

    public async Task<IEnumerable<EventLog>> DateFilter(DateFilter input)
    {
        IEnumerable<EventLog> result = await _repository!.Filter(e => e.Date >= input.StartDate && e.Date <= input.EndDate);

        return result
                .OrderByDescending(e => e.Date);
    }

    public async Task<IEnumerable<EventLog>> EventFilter(EventFilter input)
    {
        IEnumerable<EventLog> result = await _repository!.Filter(e => e.EventType == input.EventType);

        return result
                .OrderByDescending(e => e.Date);
    }

    public async Task<EventLog> Save(EventLog input)
    {
        return await _repository!.Save(input);
    }
}