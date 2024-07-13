using System.ComponentModel.DataAnnotations;

namespace EventLogs_Management.Core.Models;

public class EventFilter
{
    [Required]
    public string EventType { get; set; }

}
