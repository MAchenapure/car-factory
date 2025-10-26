using CarFactory.Sales.Domain.Entities.Cars.Enums;

namespace CarFactory.Sales.Domain.Entities.Cars
{
    public abstract class Car
    {
        public abstract CarModel Model { get; }
        public abstract decimal BasePrice { get; }
        public virtual decimal UnitPrice => BasePrice;
        public virtual decimal CalculateTotal(int units) => UnitPrice * units;
    }
}
