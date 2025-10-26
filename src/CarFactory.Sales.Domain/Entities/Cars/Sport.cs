using CarFactory.Sales.Domain.Entities.Cars.Enums;

namespace CarFactory.Sales.Domain.Entities.Cars
{
    public class Sport : Car
    {
        public override CarModel Model => CarModel.Sport;
        public override decimal BasePrice => 18200m;
        private const decimal SportExtraTax = 0.07m;
        public override decimal UnitPrice => BasePrice * (1 + SportExtraTax);
    }
}
