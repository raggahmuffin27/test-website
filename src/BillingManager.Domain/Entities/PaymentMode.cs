using BillingManager.Domain.Common;

namespace BillingManager.Domain.Entities;

public class PaymentMode : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDefault { get; set; } = false;
    public int SortOrder { get; set; } = 0;

    // Navigation properties
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}

