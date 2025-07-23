using BillingManager.Application.Interfaces;
using BillingManager.Application.Services;
using BillingManager.Domain.Entities;
using BillingManager.Domain.Enums;

namespace BillingManager.Infrastructure.Services;

public class BillService : IBillService
{
    private readonly IBillRepository _billRepository;

    public BillService(IBillRepository billRepository)
    {
        _billRepository = billRepository;
    }

    public async Task<IEnumerable<Bill>> GetAllBillsAsync()
    {
        return await _billRepository.GetAllAsync();
    }

    public async Task<Bill?> GetBillByIdAsync(int id)
    {
        return await _billRepository.GetByIdAsync(id);
    }

    public async Task<Bill> CreateBillAsync(Bill bill)
    {
        bill.CreatedAt = DateTime.UtcNow;
        bill.UpdatedAt = DateTime.UtcNow;
        
        return await _billRepository.AddAsync(bill);
    }

    public async Task<Bill> UpdateBillAsync(Bill bill)
    {
        bill.UpdatedAt = DateTime.UtcNow;
        
        await _billRepository.UpdateAsync(bill);
        return bill;
    }

    public async Task<bool> DeleteBillAsync(int id)
    {
        var bill = await _billRepository.GetByIdAsync(id);
        if (bill == null)
            return false;

        await _billRepository.DeleteAsync(bill);
        return true;
    }

    public async Task<IEnumerable<Bill>> GetBillsByCustomerIdAsync(int customerId)
    {
        return await _billRepository.GetBillsByCustomerAsync(customerId);
    }

    public async Task<IEnumerable<Bill>> GetBillsByUnitIdAsync(int unitId)
    {
        return await _billRepository.GetByUnitIdAsync(unitId);
    }

    public async Task<IEnumerable<Bill>> GetBillsByStatusAsync(BillStatus status)
    {
        return await _billRepository.GetByStatusAsync(status);
    }

    public async Task<IEnumerable<Bill>> GetOverdueBillsAsync()
    {
        return await _billRepository.GetOverdueBillsAsync();
    }

    public async Task<Bill> GenerateMonthlyDuesBillAsync(int unitId, DateTime billingPeriodStart, DateTime billingPeriodEnd)
    {
        // TODO: Implement monthly dues calculation logic
        throw new NotImplementedException("Monthly dues bill generation not yet implemented");
    }

    public async Task<Bill> GenerateUtilityBillAsync(int unitId, BillType billType, decimal previousReading, decimal currentReading, decimal rate, DateTime billingPeriodStart, DateTime billingPeriodEnd)
    {
        // TODO: Implement utility bill calculation logic
        throw new NotImplementedException("Utility bill generation not yet implemented");
    }

    public async Task<bool> ApplyPenaltyToOverdueBillsAsync()
    {
        // TODO: Implement penalty application logic
        throw new NotImplementedException("Penalty application not yet implemented");
    }

    public async Task<decimal> GetTotalOutstandingAmountAsync(int customerId)
    {
        return await _billRepository.GetTotalOutstandingAmountAsync(customerId);
    }
}
