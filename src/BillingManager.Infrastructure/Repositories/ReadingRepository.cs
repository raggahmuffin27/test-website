using BillingManager.Application.Interfaces;
using BillingManager.Domain.Entities;
using BillingManager.Domain.Enums;
using BillingManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BillingManager.Infrastructure.Repositories;

public class ReadingRepository : Repository<Reading>, IReadingRepository
{
    public ReadingRepository(BillingDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Reading>> GetByUnitIdAsync(int unitId)
    {
        return await _context.Readings
            .Where(r => r.UnitId == unitId)
            .Include(r => r.Unit)
            .OrderByDescending(r => r.ReadingDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Reading>> GetByTypeAsync(ReadingType type)
    {
        return await _context.Readings
            .Where(r => r.Type == type)
            .Include(r => r.Unit)
            .OrderByDescending(r => r.ReadingDate)
            .ToListAsync();
    }

    public async Task<Reading?> GetLatestReadingAsync(int unitId, ReadingType type)
    {
        return await _context.Readings
            .Where(r => r.UnitId == unitId && r.Type == type)
            .Include(r => r.Unit)
            .OrderByDescending(r => r.ReadingDate)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Reading>> GetForBillingPeriodAsync(DateTime startDate, DateTime endDate, ReadingType type)
    {
        return await _context.Readings
            .Where(r => r.Type == type && 
                       r.ReadingDate >= startDate && 
                       r.ReadingDate <= endDate)
            .Include(r => r.Unit)
            .OrderBy(r => r.UnitId)
            .ThenBy(r => r.ReadingDate)
            .ToListAsync();
    }
}

