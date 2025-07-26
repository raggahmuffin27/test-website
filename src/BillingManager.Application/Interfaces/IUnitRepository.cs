using BillingManager.Domain.Entities;

namespace BillingManager.Application.Interfaces;

public interface IUnitRepository : IRepository<Unit>
{
    Task<IEnumerable<Unit>> GetByFloorIdAsync(int floorId);
    Task<IEnumerable<Unit>> GetByBuildingIdAsync(int buildingId);
}

