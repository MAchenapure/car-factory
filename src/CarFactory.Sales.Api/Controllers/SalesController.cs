using Microsoft.AspNetCore.Mvc;
using MediatR;
using CarFactory.Sales.Application.Features.Sales.RegisterSale;
using CarFactory.Sales.Application.Features.Sales.GetTotalVolume;
using CarFactory.Sales.Application.Features.Sales.GetVolumeByCenter;
using CarFactory.Sales.Application.Features.Sales.GetPercentages;

namespace CarFactory.Sales.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SalesController(IMediator mediator) => _mediator = mediator;

        /// <summary>
        /// Registra una nueva venta.
        /// </summary>
        /// <param name="command">Comando con los datos de la venta.</param>
        /// <returns>Respuesta con los datos de la venta creada.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterSaleCommand command)
        {
            var res = await _mediator.Send(command);
            return CreatedAtAction(nameof(Post), new { id = res.Id }, res);
        }

        /// <summary>
        /// Obtiene el volumen total de ventas.
        /// </summary>
        [HttpGet("volume")]
        public async Task<IActionResult> GetTotalVolume() => Ok(await _mediator.Send(new GetTotalVolumeQuery()));

        /// <summary>
        /// Obtiene el volumen de ventas agrupado por centro de distribución.
        /// </summary>
        [HttpGet("volume/center")]
        public async Task<IActionResult> GetVolumeByCenter() => Ok(await _mediator.Send(new GetVolumeByCenterQuery()));

        /// <summary>
        /// Obtiene los porcentajes de ventas por modelo y centro de distribución.
        /// </summary>
        [HttpGet("percentages/center")]
        public async Task<IActionResult> GetPercentages() => Ok(await _mediator.Send(new GetPercentagesQuery()));
    }
}
