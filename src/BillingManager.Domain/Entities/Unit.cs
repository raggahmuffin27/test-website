using BillingManager.Domain.Common;

namespace BillingManager.Domain.Entities;

public class Unit : BaseEntity
{
    public string UnitNumber { get; set; } = string.Empty;
    public decimal FloorArea { get; set; }
    public decimal MonthlyDuesRate { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    // Foreign keys
    public int FloorId { get; set; }
    public int? CustomerId { get; set; }

    // Navigation properties
    public virtual Floor Floor { get; set; } = null!;
    public virtual Customer? Customer { get; set; }
    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    // Calculated property
    public decimal MonthlyDues => FloorArea * MonthlyDuesRate;
}

