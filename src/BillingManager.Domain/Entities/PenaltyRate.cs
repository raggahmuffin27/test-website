using BillingManager.Domain.Common;

namespace BillingManager.Domain.Entities;

public class PenaltyRate : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal PenaltyPercentage { get; set; }
    public int GracePeriodDays { get; set; } = 0;
    public decimal? FixedPenaltyAmount { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Description { get; set; }
}

