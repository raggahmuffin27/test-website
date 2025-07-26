using BillingManager.Domain.Entities;
using BillingManager.Domain.Enums;

namespace BillingManager.Application.Services;

public interface IReadingService
{
    Task<IEnumerable<Reading>> GetAllReadingsAsync();
    Task<Reading?> GetReadingByIdAsync(int id);
    Task<Reading> CreateReadingAsync(Reading reading);
    Task<Reading> UpdateReadingAsync(Reading reading);
    Task<bool> DeleteReadingAsync(int id);
    Task<IEnumerable<Reading>> GetReadingsByUnitIdAsync(int unitId);
    Task<IEnumerable<Reading>> GetReadingsByTypeAsync(ReadingType type);
    Task<Reading?> GetLatestReadingAsync(int unitId, ReadingType type);
    Task<bool> ImportReadingsFromExcelAsync(Stream excelStream, ReadingType type);
    Task<IEnumerable<Reading>> GetReadingsForBillingPeriodAsync(DateTime startDate, DateTime endDate, ReadingType type);
}

