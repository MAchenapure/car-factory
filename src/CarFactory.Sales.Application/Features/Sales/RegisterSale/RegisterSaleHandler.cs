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

        public async Task<RegisterSaleResponse> Handle(RegisterSaleCommand request, CancellationToken cancellationToken)
        {
            var car = Domain.Entities.Cars.Factory.CarFactory.Create(request.Model);
            var unitPrice = car.UnitPrice;
            var total = car.CalculateTotal(request.Units);

            var sale = new Sale(Guid.NewGuid(), request.CenterId, car.Model, request.Units, unitPrice, total, DateTime.UtcNow);
            await _repo.AddSaleAsync(sale);

            return new RegisterSaleResponse(sale.Id, sale.CenterId, sale.Model, sale.Units, sale.UnitPrice, sale.TotalPrice, sale.CreatedAt);
        }
    }
}
