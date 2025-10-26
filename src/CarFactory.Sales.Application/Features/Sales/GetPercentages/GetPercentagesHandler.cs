using MediatR;
using CarFactory.Sales.Application.Interfaces;
using CarFactory.Sales.Domain.Entities.Cars.Enums;

namespace CarFactory.Sales.Application.Features.Sales.GetPercentages
{
    public class GetPercentagesHandler : IRequestHandler<GetPercentagesQuery, Dictionary<string, Dictionary<CarModel, decimal>>>
    {
        private readonly ISalesRepository _repo;
        public GetPercentagesHandler(ISalesRepository repo) => _repo = repo;

        /// <summary>
        /// Maneja la consulta para obtener los porcentajes de ventas por centro y modelo.
        /// </summary>
        /// <param name="request">Consulta recibida (sin parámetros).</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>
        /// Un diccionario donde la clave es el nombre del centro y el valor es otro diccionario
        /// con el modelo de auto y su porcentaje de ventas respecto al total.
        /// </returns>
        public async Task<Dictionary<string, Dictionary<CarModel, decimal>>> Handle(GetPercentagesQuery request, CancellationToken cancellationToken)
        {
            var sales = await _repo.GetAllAsync();
            var centers = await _repo.GetCentersAsync();

            var totalUnits = sales.Sum(s => s.Units);
            if (totalUnits == 0)
                return new Dictionary<string, Dictionary<CarModel, decimal>>();

            // Agrupa las ventas por centro y luego por modelo, calculando el porcentaje de cada modelo
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
