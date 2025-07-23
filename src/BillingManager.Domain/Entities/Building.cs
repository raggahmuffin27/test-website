using BillingManager.Domain.Common;

namespace BillingManager.Domain.Entities;

public class Building : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual ICollection<Floor> Floors { get; set; } = new List<Floor>();
}

