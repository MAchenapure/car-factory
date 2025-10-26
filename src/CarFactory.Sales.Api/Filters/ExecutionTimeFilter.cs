using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace CarFactory.Sales.Api.Filters
{
    /// <summary>
    /// Filtro de acción que mide y loguea el tiempo de ejecución de cada acción del controlador.
    /// </summary>
    public class ExecutionTimeFilter : IActionFilter
    {
        private Stopwatch? _sw;
        private readonly ILogger<ExecutionTimeFilter> _logger;
        public ExecutionTimeFilter(ILogger<ExecutionTimeFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Se ejecuta antes de la acción del controlador. Inicia el cronómetro.
        /// </summary>
        public void OnActionExecuting(ActionExecutingContext context) => _sw = Stopwatch.StartNew();

        /// <summary>
        /// Se ejecuta después de la acción del controlador. Detiene el cronómetro e imprime el tiempo transcurrido.
        /// </summary>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _sw?.Stop();
            var elapsed = _sw?.ElapsedMilliseconds ?? 0;
            var action = context.ActionDescriptor.DisplayName;
            _logger.LogInformation($"[ActionExecutionTime] {action} executed in {elapsed} ms");
        }
    }
}
