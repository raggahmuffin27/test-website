using BillingManager.Domain.Entities;

namespace BillingManager.Application.Interfaces;

public interface IPaymentModeRepository : IRepository<PaymentMode>
{
    Task<IEnumerable<PaymentMode>> GetActivePaymentModesAsync(CancellationToken cancellationToken = default);
    Task<PaymentMode?> GetDefaultPaymentModeAsync(CancellationToken cancellationToken = default);
    Task<bool> SetDefaultPaymentModeAsync(int paymentModeId, CancellationToken cancellationToken = default);
}

