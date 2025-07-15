using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APC.Core.ActivityLog.Core.Enums;

namespace APC.Core.ActivityLog.Core.Entities;

public class ActivityLogEntry
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int? UserId { get; set; } // null dla akcji systemowych

    [StringLength(100)]
    public string? DisplayName { get; set; }

    [StringLength(10)]
    public string? Avatar { get; set; }

    [Required]
    [StringLength(1000)]
    public string DescriptionPrimary { get; set; } = string.Empty;

    [Required]
    [StringLength(1000)]
    public string DescriptionSecondary { get; set; } = string.Empty;

    [StringLength(100)]
    public string? ActionType { get; set; }

    [StringLength(500)]
    public string? EntityUrl { get; set; }

    [StringLength(200)]
    public string? EntityDisplayPrimary { get; set; }

    [StringLength(200)]
    public string? EntityDisplaySecondary { get; set; }

    [StringLength(100)]
    public string Icon { get; set; } = "Icons.Material.Filled.Info";

    [StringLength(50)]
    public string IconColor { get; set; } = "Color.Default";

    public ActivityLogGranularity Granularity { get; set; } = ActivityLogGranularity.Normal;

    [Required]
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
} 