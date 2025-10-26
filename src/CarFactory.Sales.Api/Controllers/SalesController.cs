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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterSaleCommand command)
        {
            var res = await _mediator.Send(command);
            return CreatedAtAction(nameof(Post), new { id = res.Id }, res);
        }

        [HttpGet("volume")]
        public async Task<IActionResult> GetTotalVolume() => Ok(await _mediator.Send(new GetTotalVolumeQuery()));

        [HttpGet("volume/center")]
        public async Task<IActionResult> GetVolumeByCenter() => Ok(await _mediator.Send(new GetVolumeByCenterQuery()));

        [HttpGet("percentages/center")]
        public async Task<IActionResult> GetPercentages() => Ok(await _mediator.Send(new GetPercentagesQuery()));
    }
}
