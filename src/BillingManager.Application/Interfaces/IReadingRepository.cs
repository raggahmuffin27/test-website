using BillingManager.Domain.Entities;
using BillingManager.Domain.Enums;

namespace BillingManager.Application.Interfaces;

public interface IReadingRepository : IRepository<Reading>
{
    Task<IEnumerable<Reading>> GetByUnitIdAsync(int unitId);
    Task<IEnumerable<Reading>> GetByTypeAsync(ReadingType type);
    Task<Reading?> GetLatestReadingAsync(int unitId, ReadingType type);
    Task<IEnumerable<Reading>> GetForBillingPeriodAsync(DateTime startDate, DateTime endDate, ReadingType type);
}

