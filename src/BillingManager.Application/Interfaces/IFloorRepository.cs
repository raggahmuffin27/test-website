using BillingManager.Domain.Entities;

namespace BillingManager.Application.Interfaces;

public interface IFloorRepository : IRepository<Floor>
{
    Task<IEnumerable<Floor>> GetByBuildingIdAsync(int buildingId);
}

