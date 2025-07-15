using Microsoft.EntityFrameworkCore;
using APC.Core.ActivityLog.Core.Entities;

namespace APC.Core.ActivityLog.Infrastructure;

public class ActivityLogDbContext : DbContext
{
    public ActivityLogDbContext(DbContextOptions<ActivityLogDbContext> options) : base(options) { }

    public DbSet<ActivityLogEntry> ActivityLogs { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("core_activitylog");
        base.OnModelCreating(modelBuilder);
    }
} 