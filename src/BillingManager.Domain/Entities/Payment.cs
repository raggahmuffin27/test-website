using BillingManager.Domain.Common;
using BillingManager.Domain.Enums;

namespace BillingManager.Domain.Entities;

public class Payment : BaseEntity
{
    public string PaymentNumber { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    public string? ReferenceNumber { get; set; }
    public string? Notes { get; set; }

    // Foreign keys
    public int CustomerId { get; set; }
    public int PaymentModeId { get; set; }

    // Navigation properties
    public virtual Customer Customer { get; set; } = null!;
    public virtual PaymentMode PaymentMode { get; set; } = null!;
    public virtual ICollection<PaymentBill> PaymentBills { get; set; } = new List<PaymentBill>();
}

