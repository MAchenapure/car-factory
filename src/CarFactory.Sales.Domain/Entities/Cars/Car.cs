using CarFactory.Sales.Domain.Entities.Cars.Enums;

namespace CarFactory.Sales.Domain.Entities.Cars
{
    /// <summary>
    /// Clase base abstracta que representa un automóvil.
    /// Define la interfaz para obtener el modelo, el precio base, el precio unitario y calcular el total.
    /// Las implementaciones concretas (Sedan, SUV, Sport, Offroad) definen los valores específicos.
    /// </summary>
    public abstract class Car
    {
        public abstract CarModel Model { get; }
        public abstract decimal BasePrice { get; }
        public virtual decimal UnitPrice => BasePrice;

        /// <summary>
        /// Calcula el precio total para una cantidad de unidades.
        /// Por defecto, multiplica el precio unitario por la cantidad.
        /// </summary>
        /// <param name="units">Cantidad de autos vendidos.</param>
        /// <returns>Precio total.</returns>
        public virtual decimal CalculateTotal(int units) => UnitPrice * units;
    }
}
