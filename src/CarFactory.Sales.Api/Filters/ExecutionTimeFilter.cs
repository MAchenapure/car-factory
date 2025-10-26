using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace CarFactory.Sales.Api.Filters
{
    public class ExecutionTimeFilter : IActionFilter
    {
        private Stopwatch? _sw;
        private readonly ILogger<ExecutionTimeFilter> _logger;
        public ExecutionTimeFilter(ILogger<ExecutionTimeFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context) => _sw = Stopwatch.StartNew();
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _sw?.Stop();
            var elapsed = _sw?.ElapsedMilliseconds ?? 0;
            var action = context.ActionDescriptor.DisplayName;
            _logger.LogInformation($"[ActionExecutionTime] {action} executed in {elapsed} ms");
        }
    }
}
