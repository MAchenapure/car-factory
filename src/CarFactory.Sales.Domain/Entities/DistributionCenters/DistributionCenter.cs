namespace CarFactory.Sales.Domain.Entities.DistributionCenters
{
    /// <summary>
    /// Representa un centro de distribución de autos.
    /// Es un record inmutable que almacena el identificador y el nombre del centro.
    /// </summary>
    /// <param name="Id">Identificador único del centro de distribución.</param>
    /// <param name="Name">Nombre descriptivo del centro de distribución.</param>
    public record DistributionCenter(int Id, string Name);
}
