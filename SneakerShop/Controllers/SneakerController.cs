using MediatR;
using Microsoft.AspNetCore.Mvc;
using SneakerShop.Commands.CreateSneaker;
using SneakerShop.Commands.DeleteSneaker;
using SneakerShop.Commands.UpdateSneaker;
using SneakerShop.Models;
using SneakerShop.Queries.GetAllSneakers;
using SneakerShop.Queries.GetSneakerById;

namespace SneakerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SneakerController : Controller
    {
        private readonly IMediator _mediator;

        public SneakerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Sneaker>))]
        public async Task<ActionResult> GetSneakers()
        {
            var query = new GetAllSneakersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{sneakerId}")]
        [ProducesResponseType(200, Type = typeof(Sneaker))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSneaker(int sneakerId)
        {
            var query = new GetSneakerByIdQuery(sneakerId);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateSneaker([FromBody] CreateSneakerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{sneakerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateSneaker([FromBody] UpdateSneakerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{sneakerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteSneaker(DeleteSneakerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
