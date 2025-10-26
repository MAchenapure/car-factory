using CarFactory.Sales.Domain.Entities.Cars.Enums;

namespace CarFactory.Sales.Domain.Entities.Cars
{
    public class SUV : Car
    {
        public override CarModel Model => CarModel.SUV;
        public override decimal BasePrice => 9500m;
    }
}
