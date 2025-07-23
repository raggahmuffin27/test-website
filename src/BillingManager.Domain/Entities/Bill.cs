using BillingManager.Domain.Common;
using BillingManager.Domain.Enums;
using BillingManager.Domain.ValueObjects;

namespace BillingManager.Domain.Entities;

public class Bill : BaseEntity
{
    public string BillNumber { get; set; } = string.Empty;
    public BillType BillType { get; set; }
    public BillStatus Status { get; set; } = BillStatus.Pending;
    public DateTime BillingPeriodStart { get; set; }
    public DateTime BillingPeriodEnd { get; set; }
    public DateTime DueDate { get; set; }
    
    // Consumption data (for utilities)
    public decimal? PreviousReading { get; set; }
    public decimal? CurrentReading { get; set; }
    public decimal? Consumption { get; set; }
    public decimal? Rate { get; set; }
    
    // Amounts
    public decimal Amount { get; set; }
    public decimal PenaltyAmount { get; set; } = 0;
    public decimal TotalAmount => Amount + PenaltyAmount;
    public decimal PaidAmount { get; set; } = 0;
    public decimal RemainingAmount => TotalAmount - PaidAmount;
    
    public string? Notes { get; set; }

    // Foreign keys
    public int CustomerId { get; set; }
    public int UnitId { get; set; }

    // Navigation properties
    public virtual Customer Customer { get; set; } = null!;
    public virtual Unit Unit { get; set; } = null!;
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    // Methods
    public bool IsOverdue => Status == BillStatus.Pending && DateTime.Now > DueDate;
    public bool IsFullyPaid => PaidAmount >= TotalAmount;
}

