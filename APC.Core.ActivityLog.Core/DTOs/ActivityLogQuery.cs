using APC.Core.ActivityLog.Core.Enums;

namespace APC.Core.ActivityLog.Core.DTOs;

/// <summary>
/// Obiekt transferu danych zawierający parametry do filtrowania i paginacji logów aktywności.
/// </summary>
public class ActivityLogQuery
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 50;
    public int? UserId { get; set; }
    public string? ActionType { get; set; }
    public ActivityLogGranularity? Granularity { get; set; }
    public string? SearchText { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Language { get; set; } = "primary";
} 