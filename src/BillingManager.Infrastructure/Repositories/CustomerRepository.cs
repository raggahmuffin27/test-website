using Microsoft.EntityFrameworkCore;
using BillingManager.Application.Interfaces;
using BillingManager.Domain.Entities;
using BillingManager.Infrastructure.Data;

namespace BillingManager.Infrastructure.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(BillingDbContext context) : base(context)
    {
    }

    public async Task<Customer?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.Email == email, cancellationToken);
    }

    public async Task<IEnumerable<Customer>> GetActiveCustomersAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(c => c.IsActive).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Customer>> GetCustomersWithUnitsAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(c => c.Units)
                .ThenInclude(u => u.Floor)
                    .ThenInclude(f => f.Building)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Customer>> SearchAsync(string searchTerm, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(c => c.FirstName.Contains(searchTerm) || 
                       c.LastName.Contains(searchTerm) || 
                       c.Email.Contains(searchTerm) ||
                       c.PhoneNumber.Contains(searchTerm))
            .ToListAsync(cancellationToken);
    }
}
