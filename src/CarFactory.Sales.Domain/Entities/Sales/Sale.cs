using CarFactory.Sales.Domain.Entities.Cars.Enums;

namespace CarFactory.Sales.Domain.Entities.Sales
{
    /// <summary>
    /// Representa una venta registrada en el sistema.
    /// Es un record inmutable que almacena los datos principales de la venta.
    /// </summary>
    /// <param name="Id">Identificador único de la venta.</param>
    /// <param name="CenterId">Identificador del centro de distribución donde se realizó la venta.</param>
    /// <param name="Model">Modelo del auto vendido.</param>
    /// <param name="Units">Cantidad de unidades vendidas.</param>
    /// <param name="UnitPrice">Precio unitario del auto en el momento de la venta.</param>
    /// <param name="TotalPrice">Precio total de la venta (unitario * cantidad).</param>
    /// <param name="CreatedAt">Fecha y hora en que se registró la venta.</param>

    public record Sale(Guid Id, int CenterId, CarModel Model, int Units, decimal UnitPrice, decimal TotalPrice, DateTime CreatedAt);
}
