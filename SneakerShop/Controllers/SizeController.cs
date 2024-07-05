using MediatR;
using Microsoft.AspNetCore.Mvc;
using SneakerShop.Commands.CreateSize;
using SneakerShop.Commands.DeleteSize;
using SneakerShop.Commands.UpdateSize;
using SneakerShop.Models;
using SneakerShop.Queries.GetAllSizes;

namespace SneakerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : Controller
    {
        private readonly IMediator _mediator;

        public SizeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Size>))]
        public async Task<IActionResult> GetSizes()
        {
            var query = new GetAllSizesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateSize([FromBody] CreateSizeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{sizeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateSize([FromBody] UpdateSizeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{sizeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteSize(DeleteSizeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
