using BillingManager.Domain.Entities;
using BillingManager.Domain.Enums;

namespace BillingManager.Application.Interfaces;

public interface IBillRepository : IRepository<Bill>
{
    Task<IEnumerable<Bill>> GetBillsByCustomerAsync(int customerId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Bill>> GetUnpaidBillsAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Bill>> GetOverdueBillsAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Bill>> GetBillsByPeriodAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    Task<IEnumerable<Bill>> GetBillsByTypeAsync(BillType billType, CancellationToken cancellationToken = default);
    Task<Bill?> GetBillWithDetailsAsync(int billId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Bill>> GetByStatusAsync(BillStatus status, CancellationToken cancellationToken = default);
    Task<IEnumerable<Bill>> GetByUnitIdAsync(int unitId, CancellationToken cancellationToken = default);
    Task<decimal> GetTotalOutstandingAmountAsync(int customerId, CancellationToken cancellationToken = default);
}
