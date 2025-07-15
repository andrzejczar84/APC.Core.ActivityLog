using APC.Core.ActivityLog.Core.Entities;
using APC.Core.ActivityLog.Core.DTOs;
using APC.Core.ActivityLog.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace APC.Core.ActivityLog.Infrastructure;

public class ActivityLogRepository
{
    private readonly ActivityLogDbContext _dbContext;
    public ActivityLogRepository(ActivityLogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(ActivityLogEntry entry)
    {
        await _dbContext.ActivityLogs.AddAsync(entry);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<ActivityLogEntry>> GetAsync(ActivityLogQuery query)
    {
        var q = _dbContext.ActivityLogs.AsQueryable();

        if (query.UserId.HasValue)
            q = q.Where(x => x.UserId == query.UserId);
        if (!string.IsNullOrEmpty(query.ActionType))
            q = q.Where(x => x.ActionType == query.ActionType);
        if (query.Granularity.HasValue)
            q = q.Where(x => x.Granularity == query.Granularity);
        if (!string.IsNullOrEmpty(query.SearchText))
            q = q.Where(x => x.DescriptionPrimary.Contains(query.SearchText) || x.DescriptionSecondary.Contains(query.SearchText));
        if (query.StartDate.HasValue)
            q = q.Where(x => x.Timestamp >= query.StartDate);
        if (query.EndDate.HasValue)
            q = q.Where(x => x.Timestamp <= query.EndDate);

        q = q.OrderByDescending(x => x.Timestamp)
               .Skip((query.PageNumber - 1) * query.PageSize)
               .Take(query.PageSize);

        return await q.ToListAsync();
    }
} 