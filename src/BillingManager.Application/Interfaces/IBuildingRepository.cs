using BillingManager.Domain.Entities;

namespace BillingManager.Application.Interfaces;

public interface IBuildingRepository : IRepository<Building>
{
    Task<IEnumerable<Building>> SearchAsync(string searchTerm);
}

