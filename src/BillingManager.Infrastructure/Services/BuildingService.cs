using BillingManager.Application.Interfaces;
using BillingManager.Application.Services;
using BillingManager.Domain.Entities;

namespace BillingManager.Infrastructure.Services;

public class BuildingService : IBuildingService
{
    private readonly IBuildingRepository _buildingRepository;

    public BuildingService(IBuildingRepository buildingRepository)
    {
        _buildingRepository = buildingRepository;
    }

    public async Task<IEnumerable<Building>> GetAllBuildingsAsync()
    {
        return await _buildingRepository.GetAllAsync();
    }

    public async Task<Building?> GetBuildingByIdAsync(int id)
    {
        return await _buildingRepository.GetByIdAsync(id);
    }

    public async Task<Building> CreateBuildingAsync(Building building)
    {
        building.CreatedAt = DateTime.UtcNow;
        building.UpdatedAt = DateTime.UtcNow;
        
        return await _buildingRepository.AddAsync(building);
    }

    public async Task<Building> UpdateBuildingAsync(Building building)
    {
        building.UpdatedAt = DateTime.UtcNow;
        
        await _buildingRepository.UpdateAsync(building);
        return building;
    }

    public async Task<bool> DeleteBuildingAsync(int id)
    {
        var building = await _buildingRepository.GetByIdAsync(id);
        if (building == null)
            return false;

        await _buildingRepository.DeleteAsync(building);
        return true;
    }

    public async Task<bool> BuildingExistsAsync(int id)
    {
        var building = await _buildingRepository.GetByIdAsync(id);
        return building != null;
    }

    public async Task<IEnumerable<Building>> SearchBuildingsAsync(string searchTerm)
    {
        return await _buildingRepository.SearchAsync(searchTerm);
    }
}
