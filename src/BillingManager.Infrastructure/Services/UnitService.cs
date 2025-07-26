using BillingManager.Application.Interfaces;
using BillingManager.Application.Services;
using BillingManager.Domain.Entities;

namespace BillingManager.Infrastructure.Services;

public class UnitService : IUnitService
{
    private readonly IUnitRepository _unitRepository;

    public UnitService(IUnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }

    public async Task<IEnumerable<Unit>> GetAllUnitsAsync()
    {
        return await _unitRepository.GetAllAsync();
    }

    public async Task<Unit?> GetUnitByIdAsync(int id)
    {
        return await _unitRepository.GetByIdAsync(id);
    }

    public async Task<Unit> CreateUnitAsync(Unit unit)
    {
        unit.CreatedAt = DateTime.UtcNow;
        unit.UpdatedAt = DateTime.UtcNow;
        
        return await _unitRepository.AddAsync(unit);
    }

    public async Task<Unit> UpdateUnitAsync(Unit unit)
    {
        unit.UpdatedAt = DateTime.UtcNow;
        
        await _unitRepository.UpdateAsync(unit);
        return unit;
    }

    public async Task<bool> DeleteUnitAsync(int id)
    {
        var unit = await _unitRepository.GetByIdAsync(id);
        if (unit == null)
            return false;

        await _unitRepository.DeleteAsync(unit);
        return true;
    }

    public async Task<IEnumerable<Unit>> GetUnitsByFloorIdAsync(int floorId)
    {
        return await _unitRepository.GetByFloorIdAsync(floorId);
    }

    public async Task<IEnumerable<Unit>> GetUnitsByBuildingIdAsync(int buildingId)
    {
        return await _unitRepository.GetByBuildingIdAsync(buildingId);
    }

    public async Task<bool> UnitExistsAsync(int id)
    {
        var unit = await _unitRepository.GetByIdAsync(id);
        return unit != null;
    }

    public async Task<decimal> CalculateMonthlyDuesAsync(int unitId)
    {
        var unit = await _unitRepository.GetByIdAsync(unitId);
        if (unit == null)
            return 0;

        // Monthly Dues = Rate * Floor Area
        return unit.MonthlyDuesRate * unit.FloorArea;
    }
}
