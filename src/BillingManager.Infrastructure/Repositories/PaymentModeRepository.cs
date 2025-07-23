using Microsoft.EntityFrameworkCore;
using BillingManager.Application.Interfaces;
using BillingManager.Domain.Entities;
using BillingManager.Infrastructure.Data;

namespace BillingManager.Infrastructure.Repositories;

public class PaymentModeRepository : Repository<PaymentMode>, IPaymentModeRepository
{
    public PaymentModeRepository(BillingDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PaymentMode>> GetActivePaymentModesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(pm => pm.IsActive)
            .OrderBy(pm => pm.SortOrder)
            .ThenBy(pm => pm.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<PaymentMode?> GetDefaultPaymentModeAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .FirstOrDefaultAsync(pm => pm.IsDefault && pm.IsActive, cancellationToken);
    }

    public async Task<bool> SetDefaultPaymentModeAsync(int paymentModeId, CancellationToken cancellationToken = default)
    {
        // Remove default from all payment modes
        var allPaymentModes = await _dbSet.ToListAsync(cancellationToken);
        foreach (var pm in allPaymentModes)
        {
            pm.IsDefault = false;
        }

        // Set the new default
        var newDefault = await _dbSet.FindAsync(new object[] { paymentModeId }, cancellationToken);
        if (newDefault != null && newDefault.IsActive)
        {
            newDefault.IsDefault = true;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        return false;
    }
}

