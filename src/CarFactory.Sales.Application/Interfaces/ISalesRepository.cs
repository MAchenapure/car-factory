using CarFactory.Sales.Domain.Entities.DistributionCenters;
using CarFactory.Sales.Domain.Entities.Sales;

namespace CarFactory.Sales.Application.Interfaces
{
    public interface ISalesRepository
    {
        Task AddSaleAsync(Sale sale);
        Task<IReadOnlyList<Sale>> GetAllAsync();
        Task<IReadOnlyList<DistributionCenter>> GetCentersAsync();
    }
}
