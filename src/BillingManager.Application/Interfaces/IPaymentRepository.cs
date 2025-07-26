using BillingManager.Domain.Entities;

namespace BillingManager.Application.Interfaces;

public interface IPaymentRepository : IRepository<Payment>
{
    Task<IEnumerable<Payment>> GetByCustomerIdAsync(int customerId);
    Task<decimal> GetOutstandingBalanceAsync(int customerId);
}

