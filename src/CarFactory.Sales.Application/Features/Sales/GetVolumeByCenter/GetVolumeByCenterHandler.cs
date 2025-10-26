using MediatR;
using System.Diagnostics;
using CarFactory.Sales.Application.Interfaces;

namespace CarFactory.Sales.Application.Features.Sales.GetVolumeByCenter
{
    public class GetVolumeByCenterHandler : IRequestHandler<GetVolumeByCenterQuery, Dictionary<string, decimal>>
    {
        private readonly ISalesRepository _repo;
        public GetVolumeByCenterHandler(ISalesRepository repo) => _repo = repo;

        public async Task<Dictionary<string, decimal>> Handle(GetVolumeByCenterQuery request, CancellationToken cancellationToken)
        {
            var sales = await _repo.GetAllAsync();
            var centers = await _repo.GetCentersAsync();

            var result = sales
                .GroupBy(s => s.CenterId)
                .ToDictionary(
                    g => centers.FirstOrDefault(c => c.Id == g.Key)?.Name ?? throw new Exception("Unknown Center"),
                    g => g.Sum(s => s.TotalPrice)
                );

            return result;
        }
    }
}
