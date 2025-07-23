using BillingManager.Domain.Entities;

namespace BillingManager.Application.Services;

public interface IFloorService
{
    Task<IEnumerable<Floor>> GetAllFloorsAsync();
    Task<Floor?> GetFloorByIdAsync(int id);
    Task<Floor> CreateFloorAsync(Floor floor);
    Task<Floor> UpdateFloorAsync(Floor floor);
    Task<bool> DeleteFloorAsync(int id);
    Task<IEnumerable<Floor>> GetFloorsByBuildingIdAsync(int buildingId);
    Task<bool> FloorExistsAsync(int id);
}

