using CarFactory.Sales.Domain.Entities.Cars.Enums;

namespace CarFactory.Sales.Domain.Entities.Cars.Factory
{
    public static class CarFactory
    {
        public static Car Create(CarModel model) => model switch
        {
            CarModel.Sedan => new Sedan(),
            CarModel.SUV => new SUV(),
            CarModel.Offroad => new Offroad(),
            CarModel.Sport => new Sport(),
            _ => throw new ArgumentOutOfRangeException(nameof(model))
        };
    }
}
