namespace CarFactory.Sales.Domain.Entities.DistributionCenters
{
    /// <summary>
    /// Representa un centro de distribuci�n de autos.
    /// Es un record inmutable que almacena el identificador y el nombre del centro.
    /// </summary>
    /// <param name="Id">Identificador �nico del centro de distribuci�n.</param>
    /// <param name="Name">Nombre descriptivo del centro de distribuci�n.</param>
    public record DistributionCenter(int Id, string Name);
}
