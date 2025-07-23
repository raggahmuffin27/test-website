using BillingManager.Domain.Entities;
using BillingManager.Domain.Enums;

namespace BillingManager.Application.Services;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> GetAllPaymentsAsync();
    Task<Payment?> GetPaymentByIdAsync(int id);
    Task<Payment> CreatePaymentAsync(Payment payment);
    Task<Payment> UpdatePaymentAsync(Payment payment);
    Task<bool> DeletePaymentAsync(int id);
    Task<IEnumerable<Payment>> GetPaymentsByCustomerIdAsync(int customerId);
    Task<Payment> ProcessMultipleBillPaymentAsync(int customerId, List<int> billIds, decimal totalAmount, int paymentModeId, string? referenceNumber = null);
    Task<Payment> ProcessAdvancePaymentAsync(int customerId, decimal amount, int paymentModeId, string? referenceNumber = null);
    Task<bool> ApplyOutstandingBalanceAsync(int customerId);
    Task<decimal> GetOutstandingBalanceAsync(int customerId);
}

