using System.ComponentModel.DataAnnotations;

namespace EventLogs_Management.Core;

public class EventLog : EntityBase
{
    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    public string? EventType { get; set; }
}