using BillingManager.Application.Interfaces;
using BillingManager.Domain.Entities;
using BillingManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BillingManager.Infrastructure.Repositories;

public class PaymentRepository : Repository<Payment>, IPaymentRepository
{
    public PaymentRepository(BillingDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Payment>> GetByCustomerIdAsync(int customerId)
    {
        return await _context.Payments
            .Where(p => p.CustomerId == customerId)
            .Include(p => p.Customer)
            .Include(p => p.PaymentMode)
            .Include(p => p.PaymentBills)
                .ThenInclude(pb => pb.Bill)
            .OrderByDescending(p => p.PaymentDate)
            .ToListAsync();
    }

    public async Task<decimal> GetOutstandingBalanceAsync(int customerId)
    {
        // Calculate outstanding balance from advance payments
        var advancePayments = await _context.Payments
            .Where(p => p.CustomerId == customerId && p.IsAdvancePayment)
            .SumAsync(p => p.Amount);

        var usedAdvancePayments = await _context.PaymentBills
            .Include(pb => pb.Payment)
            .Where(pb => pb.Payment.CustomerId == customerId && pb.Payment.IsAdvancePayment)
            .SumAsync(pb => pb.AmountPaid);

        return advancePayments - usedAdvancePayments;
    }
}

