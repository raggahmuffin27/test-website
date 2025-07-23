using BillingManager.Domain.Entities;
using BillingManager.Domain.Enums;

namespace BillingManager.Application.Services;

public interface IBillService
{
    Task<IEnumerable<Bill>> GetAllBillsAsync();
    Task<Bill?> GetBillByIdAsync(int id);
    Task<Bill> CreateBillAsync(Bill bill);
    Task<Bill> UpdateBillAsync(Bill bill);
    Task<bool> DeleteBillAsync(int id);
    Task<IEnumerable<Bill>> GetBillsByCustomerIdAsync(int customerId);
    Task<IEnumerable<Bill>> GetBillsByUnitIdAsync(int unitId);
    Task<IEnumerable<Bill>> GetBillsByStatusAsync(BillStatus status);
    Task<IEnumerable<Bill>> GetOverdueBillsAsync();
    Task<Bill> GenerateMonthlyDuesBillAsync(int unitId, DateTime billingPeriodStart, DateTime billingPeriodEnd);
    Task<Bill> GenerateUtilityBillAsync(int unitId, BillType billType, decimal previousReading, decimal currentReading, decimal rate, DateTime billingPeriodStart, DateTime billingPeriodEnd);
    Task<bool> ApplyPenaltyToOverdueBillsAsync();
    Task<decimal> GetTotalOutstandingAmountAsync(int customerId);
}

