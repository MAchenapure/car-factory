using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace CarFactory.Sales.Api.Filters
{
    /// <summary>
    /// Filtro de acci�n que mide y loguea el tiempo de ejecuci�n de cada acci�n del controlador.
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
        /// Se ejecuta antes de la acci�n del controlador. Inicia el cron�metro.
        /// </summary>
        public void OnActionExecuting(ActionExecutingContext context) => _sw = Stopwatch.StartNew();

        /// <summary>
        /// Se ejecuta despu�s de la acci�n del controlador. Detiene el cron�metro e imprime el tiempo transcurrido.
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
