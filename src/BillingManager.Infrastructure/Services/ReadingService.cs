using BillingManager.Application.Interfaces;
using BillingManager.Application.Services;
using BillingManager.Domain.Entities;
using BillingManager.Domain.Enums;

namespace BillingManager.Infrastructure.Services;

public class ReadingService : IReadingService
{
    private readonly IReadingRepository _readingRepository;

    public ReadingService(IReadingRepository readingRepository)
    {
        _readingRepository = readingRepository;
    }

    public async Task<IEnumerable<Reading>> GetAllReadingsAsync()
    {
        return await _readingRepository.GetAllAsync();
    }

    public async Task<Reading?> GetReadingByIdAsync(int id)
    {
        return await _readingRepository.GetByIdAsync(id);
    }

    public async Task<Reading> CreateReadingAsync(Reading reading)
    {
        reading.CreatedAt = DateTime.UtcNow;
        reading.UpdatedAt = DateTime.UtcNow;
        
        return await _readingRepository.AddAsync(reading);
    }

    public async Task<Reading> UpdateReadingAsync(Reading reading)
    {
        reading.UpdatedAt = DateTime.UtcNow;
        
        return await _readingRepository.UpdateAsync(reading);
    }

    public async Task<bool> DeleteReadingAsync(int id)
    {
        var reading = await _readingRepository.GetByIdAsync(id);
        if (reading == null)
            return false;

        await _readingRepository.DeleteAsync(reading);
        return true;
    }

    public async Task<IEnumerable<Reading>> GetReadingsByUnitIdAsync(int unitId)
    {
        return await _readingRepository.GetByUnitIdAsync(unitId);
    }

    public async Task<IEnumerable<Reading>> GetReadingsByTypeAsync(ReadingType type)
    {
        return await _readingRepository.GetByTypeAsync(type);
    }

    public async Task<Reading?> GetLatestReadingAsync(int unitId, ReadingType type)
    {
        return await _readingRepository.GetLatestReadingAsync(unitId, type);
    }

    public async Task<bool> ImportReadingsFromExcelAsync(Stream excelStream, ReadingType type)
    {
        // TODO: Implement Excel import logic
        throw new NotImplementedException("Excel import functionality not yet implemented");
    }

    public async Task<IEnumerable<Reading>> GetReadingsForBillingPeriodAsync(DateTime startDate, DateTime endDate, ReadingType type)
    {
        return await _readingRepository.GetForBillingPeriodAsync(startDate, endDate, type);
    }
}

