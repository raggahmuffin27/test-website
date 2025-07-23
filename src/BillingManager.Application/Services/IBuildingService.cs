using BillingManager.Domain.Entities;

namespace BillingManager.Application.Services;

public interface IBuildingService
{
    Task<IEnumerable<Building>> GetAllBuildingsAsync();
    Task<Building?> GetBuildingByIdAsync(int id);
    Task<Building> CreateBuildingAsync(Building building);
    Task<Building> UpdateBuildingAsync(Building building);
    Task<bool> DeleteBuildingAsync(int id);
    Task<bool> BuildingExistsAsync(int id);
    Task<IEnumerable<Building>> SearchBuildingsAsync(string searchTerm);
}

