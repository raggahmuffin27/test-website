using BillingManager.Domain.Common;

namespace BillingManager.Domain.Entities;

public class PaymentBill : BaseEntity
{
    public decimal AmountPaid { get; set; }
    public string? Notes { get; set; }

    // Foreign keys
    public int PaymentId { get; set; }
    public int BillId { get; set; }

    // Navigation properties
    public virtual Payment Payment { get; set; } = null!;
    public virtual Bill Bill { get; set; } = null!;
}

