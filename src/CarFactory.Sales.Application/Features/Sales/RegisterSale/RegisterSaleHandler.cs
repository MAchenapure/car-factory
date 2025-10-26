using MediatR;
using System.Diagnostics;
using CarFactory.Sales.Application.Interfaces;
using CarFactory.Sales.Domain.Entities.Sales;

namespace CarFactory.Sales.Application.Features.Sales.RegisterSale
{
    public class RegisterSaleHandler : IRequestHandler<RegisterSaleCommand, RegisterSaleResponse>
    {
        private readonly ISalesRepository _repo;

        public RegisterSaleHandler(ISalesRepository repo) => _repo = repo;

        /// <summary>
        /// Maneja el comando para registrar una venta.
        /// </summary>
        /// <param name="request">Comando con los datos de la venta.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>
        /// Un objeto con los datos de la venta registrada.
        /// </returns>
        public async Task<RegisterSaleResponse> Handle(RegisterSaleCommand request, CancellationToken cancellationToken)
        {
            // Crea una instancia del auto según el modelo solicitado y calcula el precio total según las reglas de negocio definidas.
            var car = Domain.Entities.Cars.Factory.CarFactory.Create(request.Model);
            var total = car.CalculateTotal(request.Units);
            var unitPrice = car.UnitPrice;
            
            var sale = new Sale(Guid.NewGuid(), request.CenterId, car.Model, request.Units, unitPrice, total, DateTime.UtcNow);
            await _repo.AddSaleAsync(sale);

            return new RegisterSaleResponse(sale.Id, sale.CenterId, sale.Model, sale.Units, sale.UnitPrice, sale.TotalPrice, sale.CreatedAt);
        }
    }
}
