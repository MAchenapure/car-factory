using CarFactory.Sales.Application.Features.Sales.GetTotalVolume;
using CarFactory.Sales.Application.Interfaces;
using CarFactory.Sales.Domain.Entities.Cars.Enums;
using CarFactory.Sales.Domain.Entities.Sales;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CarFactory.Sales.Tests.Application
{
    public class GetTotalVolumeHandlerTests
    {
        private readonly Mock<ISalesRepository> _mockRepo;
        private readonly GetTotalVolumeHandler _handler;

        public GetTotalVolumeHandlerTests()
        {
            _mockRepo = new Mock<ISalesRepository>();
            _handler = new GetTotalVolumeHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_Should_Return_Total_Volume()
        {
            var sales = new List<Sale>
            {
                new Sale(System.Guid.NewGuid(), 1, CarModel.Sedan, 2, 15000, 30000, System.DateTime.UtcNow),
                new Sale(System.Guid.NewGuid(), 2, CarModel.SUV, 1, 25000, 25000, System.DateTime.UtcNow)
            };

            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(sales);
            var result = await _handler.Handle(new GetTotalVolumeQuery(), CancellationToken.None);

            result.Total.Should().Be(55000);
            result.Quantity.Should().Be(2);

            _mockRepo.Verify(r => r.GetAllAsync(), Times.Once);
        }
    }
}
