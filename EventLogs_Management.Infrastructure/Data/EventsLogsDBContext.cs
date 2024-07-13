using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using EventLogs_Management.Core;
using EventLogs_Management.Core.SQL;

namespace EventLogs_Management.Infrastructure.Data;

public class EventsLogsDBContext : DbContext
{
    private readonly IOptions<SQLSettings> _options;

    public EventsLogsDBContext(IOptions<SQLSettings> options)
    {
        _options = options;
    }       

    public DbSet<EventLog> EventLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (_options is null)
            throw new ArgumentNullException("Invalid settings", nameof(SQLSettings));
       
        optionsBuilder.UseSqlServer(_options.Value.ConnectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventLog>().ToTable(nameof(EventLogs));
    }
}   