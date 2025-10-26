using CarFactory.Sales.Domain.Entities.Cars.Enums;
using MediatR;

namespace CarFactory.Sales.Application.Features.Sales.GetPercentages
{
    public record GetPercentagesQuery() : IRequest<Dictionary<string, Dictionary<CarModel, decimal>>>;
}