using BillingManager.Application.Interfaces;
using BillingManager.Application.Services;
using BillingManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BillingManager.Infrastructure.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _customerRepository.GetAllAsync();
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        return await _customerRepository.GetByIdAsync(id);
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        customer.CreatedAt = DateTime.UtcNow;
        customer.UpdatedAt = DateTime.UtcNow;
        
        return await _customerRepository.AddAsync(customer);
    }

    public async Task<Customer> UpdateCustomerAsync(Customer customer)
    {
        customer.UpdatedAt = DateTime.UtcNow;
        
        return await _customerRepository.UpdateAsync(customer);
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null)
            return false;

        await _customerRepository.DeleteAsync(customer);
        return true;
    }

    public async Task<bool> CustomerExistsAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        return customer != null;
    }

    public async Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm)
    {
        return await _customerRepository.SearchAsync(searchTerm);
    }
}

