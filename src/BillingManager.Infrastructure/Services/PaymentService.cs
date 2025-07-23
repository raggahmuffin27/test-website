using BillingManager.Application.Interfaces;
using BillingManager.Application.Services;
using BillingManager.Domain.Entities;

namespace BillingManager.Infrastructure.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
    {
        return await _paymentRepository.GetAllAsync();
    }

    public async Task<Payment?> GetPaymentByIdAsync(int id)
    {
        return await _paymentRepository.GetByIdAsync(id);
    }

    public async Task<Payment> CreatePaymentAsync(Payment payment)
    {
        payment.CreatedAt = DateTime.UtcNow;
        payment.UpdatedAt = DateTime.UtcNow;
        
        return await _paymentRepository.AddAsync(payment);
    }

    public async Task<Payment> UpdatePaymentAsync(Payment payment)
    {
        payment.UpdatedAt = DateTime.UtcNow;
        
        await _paymentRepository.UpdateAsync(payment);
        return payment;
    }

    public async Task<bool> DeletePaymentAsync(int id)
    {
        var payment = await _paymentRepository.GetByIdAsync(id);
        if (payment == null)
            return false;

        await _paymentRepository.DeleteAsync(payment);
        return true;
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByCustomerIdAsync(int customerId)
    {
        return await _paymentRepository.GetByCustomerIdAsync(customerId);
    }

    public async Task<Payment> ProcessMultipleBillPaymentAsync(int customerId, List<int> billIds, decimal totalAmount, int paymentModeId, string? referenceNumber = null)
    {
        // TODO: Implement multiple bill payment logic
        throw new NotImplementedException("Multiple bill payment processing not yet implemented");
    }

    public async Task<Payment> ProcessAdvancePaymentAsync(int customerId, decimal amount, int paymentModeId, string? referenceNumber = null)
    {
        // TODO: Implement advance payment logic
        throw new NotImplementedException("Advance payment processing not yet implemented");
    }

    public async Task<bool> ApplyOutstandingBalanceAsync(int customerId)
    {
        // TODO: Implement outstanding balance application logic
        throw new NotImplementedException("Outstanding balance application not yet implemented");
    }

    public async Task<decimal> GetOutstandingBalanceAsync(int customerId)
    {
        return await _paymentRepository.GetOutstandingBalanceAsync(customerId);
    }
}
