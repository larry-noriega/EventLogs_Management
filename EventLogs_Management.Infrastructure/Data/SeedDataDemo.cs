using EventLogs_Management.Core.Enums;
using EventLogs_Management.Core.Models;

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
                        Description = "An error occurred while processing the payment transaction.",
                        EventType = EventEnum.Error.ToString()
                    },
                    new EventLog()
                    {
                        Date = DateTime.Today.AddHours(Random.Shared.Next(-10, 0)).AddMinutes(Random.Shared.Next(-10, 0)),
                        Description = "User successfully logged in to the system.",
                        EventType = EventEnum.Login.ToString()
                    },
                    new EventLog()
                    {
                        Date = DateTime.Today.AddHours(Random.Shared.Next(-10, 0)).AddMinutes(Random.Shared.Next(-10, 0)),
                        Description = "File report.docx was deleted from the shared folder.",
                        EventType = EventEnum.Deletion.ToString()
                    },
                    new EventLog()
                    {
                        Date = DateTime.Today.AddHours(Random.Shared.Next(-10, 0)).AddMinutes(Random.Shared.Next(-10, 0)),
                        Description = "Database backup completed successfully.",
                        EventType = EventEnum.Backup.ToString()
                    },
                    new EventLog()
                    {
                        Date = DateTime.Today.AddHours(Random.Shared.Next(-10, 0)).AddMinutes(Random.Shared.Next(-10, 0)),
                        Description = "New user account john.doe was created.",
                        EventType = EventEnum.Creation.ToString()
                    },
                    new EventLog()
                    {
                        Date = DateTime.Today.AddHours(Random.Shared.Next(-10, 0)).AddMinutes(Random.Shared.Next(-10, 0)),
                        Description =  "Server reached 90% CPU utilization.",
                        EventType = EventEnum.Alert.ToString()
                    },
                    new EventLog()
                    {
                        Date = DateTime.Today.AddHours(Random.Shared.Next(-10, 0)).AddMinutes(Random.Shared.Next(-10, 0)),
                        Description =  "Network connection established with IP address 192.168.1.100.",
                        EventType = EventEnum.Connection.ToString()
                    },
                    new EventLog()
                    {
                        Date = DateTime.Today.AddHours(Random.Shared.Next(-10, 0)).AddMinutes(Random.Shared.Next(-10, 0)),
                        Description =  "User jane.smith modified the customer record.",
                        EventType = EventEnum.Modification.ToString()
                    },
                };

        db.EventLogs.AddRange(data);

        db.SaveChanges();
    }
}