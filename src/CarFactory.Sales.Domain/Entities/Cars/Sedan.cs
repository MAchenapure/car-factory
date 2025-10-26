using CarFactory.Sales.Domain.Entities.Cars.Enums;

namespace CarFactory.Sales.Domain.Entities.Cars
{
    public class Sedan : Car
    {
        public override CarModel Model => CarModel.Sedan;
        public override decimal BasePrice => 8000m;
    }
}
