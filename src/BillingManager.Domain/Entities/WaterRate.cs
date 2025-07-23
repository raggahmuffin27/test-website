using BillingManager.Domain.Common;

namespace BillingManager.Domain.Entities;

public class WaterRate : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal RatePerCubicMeter { get; set; }
    public decimal? MinimumCharge { get; set; }
    public decimal? MinimumConsumption { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Description { get; set; }
}

