using APC.Core.ActivityLog.Core.Entities;
using APC.Core.ActivityLog.Core.DTOs;

namespace APC.Core.ActivityLog.Core.Contracts;

public interface IActivityLogService
{
    /// <summary>
    /// Loguje zdarzenie w systemie.
    /// </summary>
    Task LogAsync(ActivityLogEntry entry);

    /// <summary>
    /// Pobiera stronę z logami na podstawie kryteriów zdefiniowanych w obiekcie zapytania.
    /// </summary>
    Task<IEnumerable<ActivityLogEntry>> GetLogsAsync(ActivityLogQuery query);
} 