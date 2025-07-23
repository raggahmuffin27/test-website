using BillingManager.Application.Interfaces;
using BillingManager.Application.Services;
using BillingManager.Domain.Entities;

namespace BillingManager.Infrastructure.Services;

public class FloorService : IFloorService
{
    private readonly IFloorRepository _floorRepository;

    public FloorService(IFloorRepository floorRepository)
    {
        _floorRepository = floorRepository;
    }

    public async Task<IEnumerable<Floor>> GetAllFloorsAsync()
    {
        return await _floorRepository.GetAllAsync();
    }

    public async Task<Floor?> GetFloorByIdAsync(int id)
    {
        return await _floorRepository.GetByIdAsync(id);
    }

    public async Task<Floor> CreateFloorAsync(Floor floor)
    {
        floor.CreatedAt = DateTime.UtcNow;
        floor.UpdatedAt = DateTime.UtcNow;
        
        return await _floorRepository.AddAsync(floor);
    }

    public async Task<Floor> UpdateFloorAsync(Floor floor)
    {
        floor.UpdatedAt = DateTime.UtcNow;
        
        return await _floorRepository.UpdateAsync(floor);
    }

    public async Task<bool> DeleteFloorAsync(int id)
    {
        var floor = await _floorRepository.GetByIdAsync(id);
        if (floor == null)
            return false;

        await _floorRepository.DeleteAsync(floor);
        return true;
    }

    public async Task<IEnumerable<Floor>> GetFloorsByBuildingIdAsync(int buildingId)
    {
        return await _floorRepository.GetByBuildingIdAsync(buildingId);
    }

    public async Task<bool> FloorExistsAsync(int id)
    {
        var floor = await _floorRepository.GetByIdAsync(id);
        return floor != null;
    }
}

