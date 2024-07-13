using EventLogs_Management.Core;

namespace EventLogs_Management.Infrastructure.Data;

public static class SeedDataDemo
{
    public static void Initialize(EventsLogsDBContext db)
    {
        EventLog[] data = new[]
                {
                    new EventLog()
                    {
                        Date = DateTime.Today.AddHours(Random.Shared.Next(-10, 0)).AddMinutes(Random.Shared.Next(-10, 0)),
                        Description = "Archibald",
                        EventType = "Beaker"
                    },
                    new EventLog()
                    {
                        Date = DateTime.Today.AddHours(Random.Shared.Next(-10, 0)).AddMinutes(Random.Shared.Next(-10, 0)),
                        Description = "Yasmin",
                        EventType = "Cotton"
                    },
                    new EventLog()
                    {
                        Date = DateTime.Today.AddHours(Random.Shared.Next(-10, 0)).AddMinutes(Random.Shared.Next(-10, 0)),
                        Description = "Luke",
                        EventType = "Peterson"
                    },
                    new EventLog()
                    {
                        Date = DateTime.Today.AddHours(Random.Shared.Next(-10, 0)).AddMinutes(Random.Shared.Next(-10, 0)),
                        Description = "Farrago",
                        EventType = "Rivers"
                    },
                    new EventLog()
                    {
                        Date = DateTime.Today.AddHours(Random.Shared.Next(-10, 0)).AddMinutes(Random.Shared.Next(-10, 0)),
                        Description = "Marcie",
                        EventType = "Savage"
                    }
                };

        db.EventLogs.AddRange(data);

        db.SaveChanges();
    }
}