using CarFactory.Sales.Application.Features.Sales.GetTotalVolume;
using CarFactory.Sales.Application.Features.Sales.RegisterSale;
using CarFactory.Sales.Domain.Entities.Cars.Enums;
using CarFactory.Sales.Infrastructure.Repositories;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CarFactory.Sales.Tests.Integration
{
    public class SalesFlowIntegrationTests
    {
        private readonly InMemoryRepository _repository;

        public SalesFlowIntegrationTests()
        {
            _repository = new InMemoryRepository();
        }

        [Fact]
        public async Task FullFlow_Should_Create_Sales_And_Get_TotalVolume()
        {
            var registerSaleHandler = new RegisterSaleHandler(_repository);
            var getVolumeHandler = new GetTotalVolumeHandler(_repository);

            await registerSaleHandler.Handle(new RegisterSaleCommand(0, CarModel.SUV, 1), CancellationToken.None);
            await registerSaleHandler.Handle(new RegisterSaleCommand(1, CarModel.SUV, 2), CancellationToken.None);
            var result = await getVolumeHandler.Handle(new GetTotalVolumeQuery(), CancellationToken.None);

            result.Quantity.Should().Be(32);
        }
    }
}
