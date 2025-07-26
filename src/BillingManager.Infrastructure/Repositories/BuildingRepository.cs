using BillingManager.Application.Interfaces;
using BillingManager.Domain.Entities;
using BillingManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BillingManager.Infrastructure.Repositories;

public class BuildingRepository : Repository<Building>, IBuildingRepository
{
    public BuildingRepository(BillingDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Building>> SearchAsync(string searchTerm)
    {
        return await _context.Buildings
            .Where(b => b.Name.Contains(searchTerm) || 
                       b.Address.Contains(searchTerm))
            .ToListAsync();
    }
}

