using BillingManager.Domain.Common;

namespace BillingManager.Domain.Entities;

public class Floor : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int FloorNumber { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    // Foreign keys
    public int BuildingId { get; set; }

    // Navigation properties
    public virtual Building Building { get; set; } = null!;
    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}

