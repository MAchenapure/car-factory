using CarFactory.Sales.Application.Features.Sales.GetVolumeByCenter;
using CarFactory.Sales.Application.Interfaces;
using CarFactory.Sales.Domain.Entities.Cars.Enums;
using CarFactory.Sales.Domain.Entities.DistributionCenters;
using CarFactory.Sales.Domain.Entities.Sales;
using FluentAssertions;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace CarFactory.Sales.Tests.Application
{
    public class GetVolumeByCenterHandlerTests
    {
        private readonly Mock<ISalesRepository> _mockRepo;
        private readonly GetVolumeByCenterHandler _handler;

        public GetVolumeByCenterHandlerTests()
        {
            _mockRepo = new Mock<ISalesRepository>();
            _handler = new GetVolumeByCenterHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_Should_Return_Volume_By_Center()
        {
            var centers = new List<DistributionCenter>
            {
                new DistributionCenter(1, "Norte"),
                new DistributionCenter(2, "Sur")
            };

            var sales = new List<Sale>
            {
                new Sale(Guid.NewGuid(), 1, CarModel.Sedan, 2, 10000, 20000, DateTime.UtcNow),
                new Sale(Guid.NewGuid(), 2, CarModel.SUV, 1, 20000, 20000, DateTime.UtcNow),
                new Sale(Guid.NewGuid(), 1, CarModel.SUV, 1, 20000, 20000, DateTime.UtcNow)
            };

            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(sales);
            _mockRepo.Setup(r => r.GetCentersAsync()).ReturnsAsync(centers);

            var result = await _handler.Handle(new GetVolumeByCenterQuery(), CancellationToken.None);

            result.Should().ContainKey("Norte");
            result.Should().ContainKey("Sur");

            result["Norte"].Quantity.Should().Be(2);
            result["Norte"].Total.Should().Be(40000m);
            result["Sur"].Quantity.Should().Be(1);
            result["Sur"].Total.Should().Be(20000m);

            _mockRepo.Verify(r => r.GetAllAsync(), Times.Once);
            _mockRepo.Verify(r => r.GetCentersAsync(), Times.Once);
        }
    }
}
