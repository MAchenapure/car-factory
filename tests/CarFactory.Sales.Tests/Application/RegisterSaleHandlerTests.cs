using CarFactory.Sales.Application.Features.Sales.RegisterSale;
using CarFactory.Sales.Application.Interfaces;
using CarFactory.Sales.Domain.Entities.Cars.Enums;
using CarFactory.Sales.Domain.Entities.Sales;
using FluentAssertions;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CarFactory.Sales.Tests.Application
{
    public class RegisterSaleHandlerTests
    {
        private readonly Mock<ISalesRepository> _mockRepo;
        private readonly RegisterSaleHandler _handler;

        public RegisterSaleHandlerTests()
        {
            _mockRepo = new Mock<ISalesRepository>();
            _handler = new RegisterSaleHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_Should_Create_Sale_Successfully()
        {
            var command = new RegisterSaleCommand(0, CarModel.Sedan, 1);
            _mockRepo.Setup(r => r.AddSaleAsync(It.IsAny<Sale>())).Returns(Task.CompletedTask);

            var result = await _handler.Handle(command, CancellationToken.None);

            result.CenterId.Should().Be(command.CenterId);
            result.Model.Should().Be(command.Model);
            result.Units.Should().Be(command.Units);
            result.Id.Should().NotBeEmpty();
            result.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
            result.TotalPrice.Should().BeGreaterThan(0);
            result.UnitPrice.Should().BeGreaterThan(0);

            _mockRepo.Verify(r => r.AddSaleAsync(It.Is<Sale>(s => s.Model == CarModel.Sedan && s.Units == 1)), Times.Once);
        }
    }
}
