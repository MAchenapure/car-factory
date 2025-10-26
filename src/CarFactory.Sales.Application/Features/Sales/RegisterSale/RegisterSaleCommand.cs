using MediatR;
using CarFactory.Sales.Domain.Entities.Cars.Enums;

namespace CarFactory.Sales.Application.Features.Sales.RegisterSale
{
    public record RegisterSaleCommand(int CenterId, CarModel Model, int Units) : IRequest<RegisterSaleResponse>;

    public record RegisterSaleResponse(Guid Id, int CenterId, CarModel Model, int Units, decimal UnitPrice, decimal TotalPrice, DateTime CreatedAt);
}
