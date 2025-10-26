using CarFactory.Sales.Domain.Entities.Cars;
using CarFactory.Sales.Domain.Entities.Cars.Enums;
using FluentAssertions;
using Xunit;

namespace CarFactory.Sales.Tests.Domain.Entities.Cars
{
    public class SportTests
    {
        [Fact]
        public void Model_Should_Be_Sport()
        {
            var sport = new Sport();
            sport.Model.Should().Be(CarModel.Sport);
        }

        [Fact]
        public void BasePrice_Should_Be_18200()
        {
            var sport = new Sport();
            sport.BasePrice.Should().Be(18200m);
        }

        [Fact]
        public void UnitPrice_Should_Include_ExtraTax()
        {
            var sport = new Sport();
            var expected = 18200m * 1.07m;
            sport.UnitPrice.Should().BeApproximately(expected, 0.01m);
        }
    }
}
