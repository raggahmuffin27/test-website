using BillingManager.Application.Interfaces;
using BillingManager.Domain.Entities;
using BillingManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BillingManager.Infrastructure.Repositories;

public class FloorRepository : Repository<Floor>, IFloorRepository
{
    public FloorRepository(BillingDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Floor>> GetByBuildingIdAsync(int buildingId)
    {
        return await _context.Floors
            .Where(f => f.BuildingId == buildingId)
            .Include(f => f.Building)
            .Include(f => f.Units)
            .ToListAsync();
    }
}

