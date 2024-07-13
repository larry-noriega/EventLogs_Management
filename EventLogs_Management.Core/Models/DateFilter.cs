using System.ComponentModel.DataAnnotations;

namespace EventLogs_Management.Core.Models;

public class DateFilter
{
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
}
