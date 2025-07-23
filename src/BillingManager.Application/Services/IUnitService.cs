using BillingManager.Domain.Entities;

namespace BillingManager.Application.Services;

public interface IUnitService
{
    Task<IEnumerable<Unit>> GetAllUnitsAsync();
    Task<Unit?> GetUnitByIdAsync(int id);
    Task<Unit> CreateUnitAsync(Unit unit);
    Task<Unit> UpdateUnitAsync(Unit unit);
    Task<bool> DeleteUnitAsync(int id);
    Task<IEnumerable<Unit>> GetUnitsByFloorIdAsync(int floorId);
    Task<IEnumerable<Unit>> GetUnitsByBuildingIdAsync(int buildingId);
    Task<bool> UnitExistsAsync(int id);
    Task<decimal> CalculateMonthlyDuesAsync(int unitId);
}

