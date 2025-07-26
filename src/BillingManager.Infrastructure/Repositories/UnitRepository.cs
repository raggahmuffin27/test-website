using BillingManager.Application.Interfaces;
using BillingManager.Domain.Entities;
using BillingManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BillingManager.Infrastructure.Repositories;

public class UnitRepository : Repository<Unit>, IUnitRepository
{
    public UnitRepository(BillingDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Unit>> GetByFloorIdAsync(int floorId)
    {
        return await _context.Units
            .Where(u => u.FloorId == floorId)
            .Include(u => u.Floor)
            .Include(u => u.Customer)
            .ToListAsync();
    }

    public async Task<IEnumerable<Unit>> GetByBuildingIdAsync(int buildingId)
    {
        return await _context.Units
            .Include(u => u.Floor)
            .Where(u => u.Floor.BuildingId == buildingId)
            .Include(u => u.Customer)
            .ToListAsync();
    }
}

