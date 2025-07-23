using BillingManager.Domain.Entities;

namespace BillingManager.Application.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<IEnumerable<Customer>> GetActiveCustomersAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Customer>> GetCustomersWithUnitsAsync(CancellationToken cancellationToken = default);
}

