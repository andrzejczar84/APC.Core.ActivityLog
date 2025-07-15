using APC.Core.ActivityLog.Core.Contracts;
using APC.Core.ActivityLog.Core.Entities;
using APC.Core.ActivityLog.Core.DTOs;
using APC.Core.ActivityLog.Core.Enums;
using APC.Core.ActivityLog.Infrastructure;

namespace APC.Core.ActivityLog.Application;

public class ActivityLogService : IActivityLogService
{
    private readonly ActivityLogRepository _repository;
    public ActivityLogService(ActivityLogRepository repository)
    {
        _repository = repository;
    }

    public async Task LogAsync(ActivityLogEntry entry)
    {
        // Mapowanie domyślnych ikon, kolorów, granularity na podstawie typu akcji
        if (string.IsNullOrEmpty(entry.Icon))
        {
            entry.Icon = entry.Granularity switch
            {
                ActivityLogGranularity.Critical => "Icons.Material.Filled.Error",
                ActivityLogGranularity.Major => "Icons.Material.Filled.Warning",
                ActivityLogGranularity.Normal => "Icons.Material.Filled.Info",
                ActivityLogGranularity.Minor => "Icons.Material.Filled.Edit",
                _ => "Icons.Material.Filled.Info"
            };
        }
        if (string.IsNullOrEmpty(entry.IconColor))
        {
            entry.IconColor = entry.Granularity switch
            {
                ActivityLogGranularity.Critical => "Color.Error",
                ActivityLogGranularity.Major => "Color.Warning",
                ActivityLogGranularity.Normal => "Color.Info",
                ActivityLogGranularity.Minor => "Color.Default",
                _ => "Color.Default"
            };
        }
        await _repository.AddAsync(entry);
    }

    public async Task<IEnumerable<ActivityLogEntry>> GetLogsAsync(ActivityLogQuery query)
    {
        return await _repository.GetAsync(query);
    }
} 