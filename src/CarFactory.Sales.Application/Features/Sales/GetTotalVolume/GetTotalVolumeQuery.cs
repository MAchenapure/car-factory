using MediatR;

namespace CarFactory.Sales.Application.Features.Sales.GetTotalVolume
{
    public record GetTotalVolumeQuery() : IRequest<GetTotalVolumenResponse>;

    public record GetTotalVolumenResponse(int Quantity, decimal Total);
}
