using CarFactory.Sales.Domain.Entities.Cars.Enums;
using MediatR;

namespace CarFactory.Sales.Application.Features.Sales.GetVolumeByCenter
{
    public record GetVolumeByCenterQuery() : IRequest<Dictionary<string, decimal>>;
}