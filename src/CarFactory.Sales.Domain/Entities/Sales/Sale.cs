using CarFactory.Sales.Domain.Entities.Cars.Enums;

namespace CarFactory.Sales.Domain.Entities.Sales
{
    public record Sale(Guid Id, int CenterId, CarModel Model, int Units, decimal UnitPrice, decimal TotalPrice, DateTime CreatedAt);
}
