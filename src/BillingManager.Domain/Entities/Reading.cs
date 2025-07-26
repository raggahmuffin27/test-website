using BillingManager.Domain.Common;
using BillingManager.Domain.Enums;

namespace BillingManager.Domain.Entities;

public class Reading : BaseEntity
{
    public int UnitId { get; set; }
    public ReadingType Type { get; set; }
    public decimal PreviousReading { get; set; }
    public decimal CurrentReading { get; set; }
    public decimal Consumption => CurrentReading - PreviousReading;
    public DateTime ReadingDate { get; set; }
    public string? Notes { get; set; }

    // Navigation properties
    public Unit Unit { get; set; } = null!;
}
