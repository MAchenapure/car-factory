using CarFactory.Sales.Application.Interfaces;
using CarFactory.Sales.Domain.Entities.Cars.Enums;
using CarFactory.Sales.Domain.Entities.DistributionCenters;
using CarFactory.Sales.Domain.Entities.Sales;

namespace CarFactory.Sales.Infrastructure.Repositories
{
    public class InMemoryRepository : ISalesRepository
    {
        private readonly List<Sale> _sales = new();
        private readonly List<DistributionCenter> _centers = new();

        public InMemoryRepository()
        {
            _centers.AddRange(new[] {
                new DistributionCenter(0, "Norte"),
                new DistributionCenter(1, "Sur"),
                new DistributionCenter(2, "Este"),
                new DistributionCenter(3, "Oeste"),
            });

            var rand = new Random(42);
            var models = Enum.GetValues(typeof(CarModel)).Cast<CarModel>().ToArray();
            for (int i = 0; i < 30; i++)
            {
                var model = models[rand.Next(models.Length)];
                var center = rand.Next(0, 4);
                var units = rand.Next(1, 5);
                var car = Domain.Entities.Cars.Factory.CarFactory.Create(model);
                var total = car.CalculateTotal(units);
                _sales.Add(new Sale(Guid.NewGuid(), center, model, units, car.UnitPrice, total, DateTime.UtcNow.AddDays(-rand.Next(0, 30))));
            }
        }

        public Task AddSaleAsync(Sale sale)
        {
            _sales.Add(sale);
            return Task.CompletedTask;
        }

        public Task<IReadOnlyList<Sale>> GetAllAsync() => Task.FromResult((IReadOnlyList<Sale>)_sales.AsReadOnly());

        public Task<IReadOnlyList<DistributionCenter>> GetCentersAsync() => Task.FromResult((IReadOnlyList<DistributionCenter>)_centers.AsReadOnly());
    }
}
