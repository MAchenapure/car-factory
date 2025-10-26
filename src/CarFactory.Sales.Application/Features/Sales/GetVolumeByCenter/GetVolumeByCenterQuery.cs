using CarFactory.Sales.Application.Features.Sales.GetTotalVolume;
using MediatR;

namespace CarFactory.Sales.Application.Features.Sales.GetVolumeByCenter
{
    public record GetVolumeByCenterQuery() : IRequest<Dictionary<string, GetTotalVolumenResponse>>;
}