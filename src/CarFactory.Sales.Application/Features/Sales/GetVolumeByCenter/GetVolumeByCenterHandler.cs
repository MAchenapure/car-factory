using MediatR;
using CarFactory.Sales.Application.Interfaces;
using CarFactory.Sales.Application.Features.Sales.GetTotalVolume;

namespace CarFactory.Sales.Application.Features.Sales.GetVolumeByCenter
{
    public class GetVolumeByCenterHandler : IRequestHandler<GetVolumeByCenterQuery, Dictionary<string, GetTotalVolumenResponse>>
    {
        private readonly ISalesRepository _repo;
        public GetVolumeByCenterHandler(ISalesRepository repo) => _repo = repo;

        /// <summary>
        /// Maneja la consulta para obtener la cantidad de ventas y el monto total por cada centro de distribución.
        /// </summary>
        /// <param name="request">Consulta recibida (sin parámetros).</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>
        /// Un diccionario donde la clave es el nombre del centro y el valor es un objeto con la cantidad de ventas y el monto total vendido.
        /// </returns>
        public async Task<Dictionary<string, GetTotalVolumenResponse>> Handle(GetVolumeByCenterQuery request, CancellationToken cancellationToken)
        {
            var sales = await _repo.GetAllAsync();
            var centers = await _repo.GetCentersAsync();

            // Agrupa las ventas por centro y calcula la cantidad de ventas y el monto total por cada uno de ellos.
            var result = sales
                .GroupBy(s => s.CenterId)
                .ToDictionary(
                    g => centers.FirstOrDefault(c => c.Id == g.Key)?.Name ?? throw new Exception("Unknown Center"),
                    g => new GetTotalVolumenResponse(
                        g.Count(),
                        g.Sum(s => s.TotalPrice)
                    )
                );

            return result;
        }
    }
}
