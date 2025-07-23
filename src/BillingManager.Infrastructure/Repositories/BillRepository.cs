using Microsoft.EntityFrameworkCore;
using BillingManager.Application.Interfaces;
using BillingManager.Domain.Entities;
using BillingManager.Domain.Enums;
using BillingManager.Infrastructure.Data;

namespace BillingManager.Infrastructure.Repositories;

public class BillRepository : Repository<Bill>, IBillRepository
{
    public BillRepository(BillingDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Bill>> GetBillsByCustomerAsync(int customerId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(b => b.CustomerId == customerId)
            .Include(b => b.Unit)
            .OrderByDescending(b => b.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Bill>> GetUnpaidBillsAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(b => b.Status == BillStatus.Pending || b.Status == BillStatus.PartiallyPaid)
            .Include(b => b.Customer)
            .Include(b => b.Unit)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Bill>> GetOverdueBillsAsync(CancellationToken cancellationToken = default)
    {
        var today = DateTime.Now.Date;
        return await _dbSet
            .Where(b => (b.Status == BillStatus.Pending || b.Status == BillStatus.PartiallyPaid) 
                       && b.DueDate < today)
            .Include(b => b.Customer)
            .Include(b => b.Unit)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Bill>> GetBillsByPeriodAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(b => b.BillingPeriodStart >= startDate && b.BillingPeriodEnd <= endDate)
            .Include(b => b.Customer)
            .Include(b => b.Unit)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Bill>> GetBillsByTypeAsync(BillType billType, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(b => b.BillType == billType)
            .Include(b => b.Customer)
            .Include(b => b.Unit)
            .ToListAsync(cancellationToken);
    }

    public async Task<Bill?> GetBillWithDetailsAsync(int billId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(b => b.Customer)
            .Include(b => b.Unit)
                .ThenInclude(u => u.Floor)
                    .ThenInclude(f => f.Building)
            .Include(b => b.PaymentBills)
                .ThenInclude(pb => pb.Payment)
                    .ThenInclude(p => p.PaymentMode)
            .FirstOrDefaultAsync(b => b.Id == billId, cancellationToken);
    }
}
