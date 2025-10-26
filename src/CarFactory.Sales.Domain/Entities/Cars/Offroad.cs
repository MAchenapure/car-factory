using CarFactory.Sales.Domain.Entities.Cars.Enums;

namespace CarFactory.Sales.Domain.Entities.Cars
{
    public class Offroad : Car
    {
        public override CarModel Model => CarModel.Offroad;
        public override decimal BasePrice => 12500m;
    }
}
