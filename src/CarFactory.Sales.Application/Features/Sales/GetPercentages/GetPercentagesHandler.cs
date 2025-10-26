using MediatR;
using System.Diagnostics;
using CarFactory.Sales.Application.Interfaces;
using CarFactory.Sales.Domain.Entities.Cars.Enums;

namespace CarFactory.Sales.Application.Features.Sales.GetPercentages
{
    public class GetPercentagesHandler : IRequestHandler<GetPercentagesQuery, Dictionary<string, Dictionary<CarModel, decimal>>>
    {
        private readonly ISalesRepository _repo;
        public GetPercentagesHandler(ISalesRepository repo) => _repo = repo;

        public async Task<Dictionary<string, Dictionary<CarModel, decimal>>> Handle(GetPercentagesQuery request, CancellationToken cancellationToken)
        {
            var sales = await _repo.GetAllAsync();
            var centers = await _repo.GetCentersAsync();

            var totalUnits = sales.Sum(s => s.Units);
            if (totalUnits == 0)
                return new Dictionary<string, Dictionary<CarModel, decimal>>();

            var result = sales
                .GroupBy(s => s.CenterId)
                .ToDictionary(
                    g => centers.FirstOrDefault(c => c.Id == g.Key)?.Name ?? throw new Exception("Unknown Center"),
                    g => g.GroupBy(x => x.Model)
                          .ToDictionary(
                              gg => gg.Key,
                              gg => Math.Round((decimal)gg.Sum(x => x.Units) / totalUnits * 100m, 2)
                          )
                );

            return result;
        }
    }
}
