using MediatR;
using System.Diagnostics;
using CarFactory.Sales.Application.Interfaces;

namespace CarFactory.Sales.Application.Features.Sales.GetTotalVolume
{
    public class GetTotalVolumeHandler : IRequestHandler<GetTotalVolumeQuery, GetTotalVolumenResponse>
    {
        private readonly ISalesRepository _repo;
        public GetTotalVolumeHandler(ISalesRepository repo) => _repo = repo;

        public async Task<GetTotalVolumenResponse> Handle(GetTotalVolumeQuery request, CancellationToken cancellationToken)
        {
            var sales = await _repo.GetAllAsync();
            return new GetTotalVolumenResponse(sales.Count, sales.Sum(s => s.TotalPrice));
        }
    }
}
