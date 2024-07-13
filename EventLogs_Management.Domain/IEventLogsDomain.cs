using EventLogs_Management.Core.Models;

namespace EventLogs_Management.Domain
{
    public interface IEventLogsDomain
    {
        Task<IEnumerable<EventLog>> DateFilter(DateFilter input);
        Task<IEnumerable<EventLog>> EventFilter(EventFilter input);
        Task<IEnumerable<EventLog>> GetLogList();
        Task<EventLog> Save(EventLog input);
    }
}